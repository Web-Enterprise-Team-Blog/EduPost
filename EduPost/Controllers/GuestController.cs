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

        public async Task<IActionResult> Index()
        {
            var guest = _userManager.GetUserAsync(User).Result;
            string faculty = guest.Faculty;

            GuestIndexViewModel model = new GuestIndexViewModel();
            model.f1 = await _context.Article.Include(a => a.Files).Include(a => a.User).Where(a => a.Faculty == faculty && a.StatusId == 1 && a.Public).OrderBy(a => a.CreatedDate).Take(3).ToListAsync();
            model.f2 = await _context.Article.Include(a => a.Files).Include(a => a.User).Where(a => a.Faculty == faculty && a.StatusId == 1 && a.Public).OrderBy(a => a.ArticleTitle).Take(4).ToListAsync();
            model.f3 = await _context.Article.Include(a => a.Files).Include(a => a.User).Where(a => a.Faculty == faculty && a.StatusId == 1 && a.Public).OrderByDescending(a => a.CreatedDate).Take(3).ToListAsync();

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

            if (article == null)
            {
                return NotFound();
            }
            return View(article);
        }        
    }
    public class GuestIndexViewModel
    {
        public List<Article> f1 = new List<Article>();
        public List<Article> f2 = new List<Article>();
        public List<Article> f3 = new List<Article>();
    }
}