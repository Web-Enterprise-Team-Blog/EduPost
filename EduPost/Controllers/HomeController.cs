using EduPost.Data;
using EduPost.Models;
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
		private readonly UserManager<User> _userManager;

		public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, UserManager<User> userManager)
        {
            _logger = logger;
			_context = context;
			_userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
			var user = _userManager.GetUserAsync(User).Result;
			string faculty = user.Faculty;

			HomeIndexViewModel model = new HomeIndexViewModel();
			//remember to readjust filter to prevent the same content appearing twice
			model.f1 = await _context.Article.Include(a => a.User).Where(a => a.Faculty == faculty && a.StatusId == 1 && a.Public).OrderBy(a => a.CreatedDate).Take(3).ToListAsync();
			model.f2 = await _context.Article.Include(a => a.User).Where(a => a.Faculty == faculty && a.StatusId == 1 && a.Public).OrderBy(a => a.CreatedDate).Take(3).ToListAsync();
			model.f3 = await _context.Article.Include(a => a.User).Where(a => a.Faculty == faculty && a.StatusId == 1 && a.Public).OrderBy(a => a.CreatedDate).Take(3).ToListAsync();
			model.f4 = await _context.Article.Include(a => a.User).Where(a => a.Faculty == faculty && a.StatusId == 1 && a.Public).OrderBy(a => a.CreatedDate).Take(5).ToListAsync();
			model.f5 = await _context.Article.Include(a => a.User).Where(a => a.Faculty == faculty && a.StatusId == 1 && a.Public).OrderBy(a => a.CreatedDate).Take(3).ToListAsync();
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
		public List<Article> f1 = new List<Article>();   //Information Tecnology
		public List<Article> f2 = new List<Article>();   //Computer Science
		public List<Article> f3 = new List<Article>();   //Economics
		public List<Article> f4 = new List<Article>();   //Environmental Science
		public List<Article> f5 = new List<Article>();   //Psychology
	}
}
