using EduPost.Data;
using EduPost.Models;
using EduPost.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace EduPost.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
		private readonly ApplicationDbContext _context;
		private readonly NotificationHub _notificationHub;
		private readonly UserManager<User> _userManager;

		public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, UserManager<User> userManager, NotificationHub notificationHub)
        {
            _logger = logger;
			_context = context;
			_userManager = userManager;
            _notificationHub = notificationHub;
        }

        public async Task<IActionResult> Index()
        {
			var user = _userManager.GetUserAsync(User).Result;
			string faculty = user.Faculty;

			HomeIndexViewModel model = new HomeIndexViewModel();
			model.f1 = await _context.Article.Include(a => a.User).Where(a => a.Faculty == faculty && a.StatusId == 1 && a.Public).OrderBy(a => a.CreatedDate).Take(3).ToListAsync();
			model.f2 = await _context.Article
	            .Include(a => a.User)
	            .Where(a => a.Faculty == faculty && a.StatusId == 1 && a.Public)
	            .OrderByDescending(a => _context.UserReaction
		            .Where(ur => ur.ArticleId == a.ArticleId && ur.ReactionType)
		            .Count())
	            .Take(3)
	            .ToListAsync();
			model.f3 = await _context.Article
				.Include(a => a.User)
				.Where(a => a.Faculty == faculty && a.StatusId == 1 && a.Public)
				.OrderByDescending(a => _context.Comment
					.Where(ur => ur.ArticleId == a.ArticleId)
					.Count())
				.Take(3)
				.ToListAsync();
			return View(model);
		}

        public async Task<IActionResult> Notifications()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (user == null)
            {
                return Content("User not found or not logged in.");
            }

            var userId = user.Id;
            var notifications = await _context.Notification
                                              .Where(n => n.UserId == userId)
                                              .OrderByDescending(n => n.Timestamp)
                                              .Take(5)
                                              .ToListAsync();
            return View(notifications);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Article == null)
            {
                return NotFound();
            }

            var article = await _context.Article
                .Include(a => a.Files)
                .Include(a => a.Comments)
                .FirstOrDefaultAsync(a => a.ArticleId == id);

            var userIds = article.Comments.Select(c => c.UserId).Distinct();
            var users = await _context.Users
                .Where(u => userIds.Contains(u.Id))
                .ToDictionaryAsync(u => u.Id, u => u.UserName);

            ViewBag.Usernames = users;

			var creatorUsername = await _context.Users
	            .Where(u => u.Id == article.UserID) 
	            .Select(u => u.UserName)
	            .FirstOrDefaultAsync();

			if (creatorUsername == null)
			{
				creatorUsername = "Unknown User";
			}

			ViewBag.CreatorUsername = creatorUsername;

			if (article == null)
            {
                return NotFound();
            }
            return View(article);
        }

		[HttpPost]
		public async Task<IActionResult> AddComment(int ArticleId, string Content)
		{
			var user = await _userManager.GetUserAsync(User);
			var article = await _context.Article.FindAsync(ArticleId);

			if (user == null)
			{
				return Unauthorized();
			}
			var comment = new Comment
			{
				ArticleId = ArticleId,
				Content = Content,
				CreatedDate = DateTimeOffset.Now,
				UserId = user.Id
			};

			_context.Comment.Add(comment);
			await _context.SaveChangesAsync();

			var message = $"User: \"{_userManager.GetUserAsync(User).Result.UserName}\" has commented on your article: \"{article.ArticleTitle}\"  .";
			await _notificationHub.SendNotificationToUser(message, article.UserID);

			return RedirectToAction("Details", new { id = ArticleId });
		}

        [HttpPost]
        public async Task<IActionResult> DeleteComment(int commentId)
        {
            var comment = await _context.Comment.FindAsync(commentId);
            if (comment == null)
            {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized();
            }

            if (comment.UserId != user.Id)
            {
                return Forbid("You can delete only your own feedback!");
            }

            _context.Comment.Remove(comment);
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", new { id = comment.ArticleId });
        }

        public IActionResult Profile()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
	public class HomeIndexViewModel
	{
		public List<Article> f1 = new List<Article>();
		public List<Article> f2 = new List<Article>();  
		public List<Article> f3 = new List<Article>();   
	}
}
