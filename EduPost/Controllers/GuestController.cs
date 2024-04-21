using EduPost.Data;
using EduPost.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduPost.Controllers
{
    [Authorize]
    public class GuestController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public GuestController(ApplicationDbContext context, UserManager<User> userManager, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _userManager = userManager;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var guest = _userManager.GetUserAsync(User).Result;
            string faculty = guest.Faculty;

            GuestIndexViewModel model = new GuestIndexViewModel();
            model.f1 = await _context.Article
            .Include(a => a.User)
				.Where(a => a.Faculty == faculty && a.StatusId == 1 && a.Public == true)
				.Select(a => new ArticleViewModel
				{
					Article = a,
					CommentCount = a.Comments.Count,
					LikeCount = a.UserReactions.Count(fb => fb.ReactionType == true)
				})
				.OrderByDescending(a => a.Article.CreatedDate)
				.Take(3)
				.ToListAsync();

			model.f2 = await _context.Article
                .Include(a => a.User)
				.Where(a => a.Faculty == faculty && a.StatusId == 1 && a.Public == true)
				.Select(a => new ArticleViewModel
				{
					Article = a,
					CommentCount = a.Comments.Count,
					LikeCount = a.UserReactions.Count(fb => fb.ReactionType == true)
				})
				.OrderByDescending(a => a.LikeCount)
				.Take(3)
				.ToListAsync();
			model.f3 = await _context.Article
				.Include(a => a.User)
				.Where(a => a.Faculty == faculty && a.StatusId == 1 && a.Public == true)
				.Select(a => new ArticleViewModel
				{
					Article = a,
					CommentCount = a.Comments.Count,
					LikeCount = a.UserReactions.Count(fb => fb.ReactionType == true)
				})
				.OrderByDescending(a => a.CommentCount)
				.Take(3)
				.ToListAsync();

			if (model == null)
            {
                return RedirectToAction("NotFound", "Error");
            }

            return View(model);
        }

        // GET: Articles/Details/5
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
    }
    public class GuestIndexViewModel
    {
        public List<ArticleViewModel> f1 = new List<ArticleViewModel>();
        public List<ArticleViewModel> f2 = new List<ArticleViewModel>();
        public List<ArticleViewModel> f3 = new List<ArticleViewModel>();
    }
}