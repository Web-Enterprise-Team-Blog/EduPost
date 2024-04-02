using EduPost.Data;
using EduPost.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using File = EduPost.Models.File;

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

		public IActionResult Index()
		{
			var guest = _userManager.GetUserAsync(User).Result;
			var faculty = guest.Faculty;

			var articles = _context.Article
				.Include(a => a.Files)
				.Where(a => _context.User.Any(u => u.Id == a.UserID && u.Faculty == faculty) && a.StatusId == 1 && a.Public)
				.ToList();

			if (articles == null)
			{
				return RedirectToAction("NotFound", "Error");
			}

			return View(articles);
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
				.FirstOrDefaultAsync(a => a.ArticleId == id);

			if (article == null)
			{
				return NotFound();
			}
			return View(article);
		}
	}
}