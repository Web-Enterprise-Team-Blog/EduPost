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
    public class CoordinatorController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CoordinatorController(ApplicationDbContext context, UserManager<User> userManager, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _userManager = userManager;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
                var coordinator = _userManager.GetUserAsync(User).Result;
                var faculty = coordinator.Faculty;

                var articles = _context.Article
                    .Include(a => a.Files)
                    .Where(a => _context.User.Any(u => u.Id == a.UserID && u.Faculty == faculty) && a.StatusId == 1)
                    .ToList();

                if (articles == null)
                {
                    return RedirectToAction("NotFound", "Error");
                }

                return View(articles);
        }

        public async Task<IActionResult> Articles()
        {
            bool isCoordinator = User.IsInRole("Coordinator");

            if (isCoordinator)
            {
                var coordinator = await _userManager.GetUserAsync(User);
                var faculty = coordinator.Faculty;

                var articles = await _context.Article
                    .Join(_context.User,
                        article => article.UserID,
                        user => user.Id,
                        (article, user) => new { Article = article, User = user })
                    .Where(x => x.User.Faculty == faculty)
                    .Select(x => x.Article)
                    .Where(a => a.StatusId != 1)
                    .ToListAsync();

                return View(articles);
            }
            else
            {
                var userIdAsString = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (int.TryParse(userIdAsString, out int userId))
                {
                    var articles = await _context.Article
                        .Where(a => a.UserID == userId)
                        .ToListAsync();

                    return View(articles);
                }

                return View(new List<Article>());
            }
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

        public async Task<IActionResult> ApproveStatus(int articleId)
        {
            var article = await _context.Article.FindAsync(articleId);
            if (article != null)
            {
                article.StatusId = 1;
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Articles));
        }

        public async Task<IActionResult> DeclineStatus(int articleId)
        {
            var article = await _context.Article.FindAsync(articleId);
            if (article != null)
            {
                article.StatusId = 2;
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Articles));
        }

        // GET: Articles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Article == null)
            {
                return NotFound();
            }

            var article = await _context.Article
                .FirstOrDefaultAsync(m => m.ArticleId == id);
            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // POST: Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Nullable<int> id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.Article
                .Include(a => a.Files)
                .FirstOrDefaultAsync(m => m.ArticleId == id);

            if (article == null)
            {
                return NotFound();
            }

            foreach (var file in article.Files)
            {
                string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", file.FileName);
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }

                _context.File.Remove(file);
            }

            // Delete the Article object
            _context.Article.Remove(article);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool ArticleExists(int? id)
        {
            return (_context.Article?.Any(e => e.ArticleId == id)).GetValueOrDefault();
        }

        [HttpPost]
        public IActionResult CheckExpiredArticles()
        {
            var articles = _context.Article
                .Where(a => a.StatusId == 0)
                .ToList();

            var expiredArticles = articles
                .Where(a => a.IsExpired)
                .ToList();

            foreach (var article in expiredArticles)
            {
                article.StatusId = 3;
            }

            _context.SaveChanges();
            return RedirectToAction("Articles");
        }

        public IActionResult ExtendDeadline(int articleId)
        {
            var article = _context.Article.Find(articleId);
            if (article != null)
            {
                article.ExpireDate = DateTime.UtcNow.AddDays(7);
                article.StatusId = 0;
                _context.SaveChanges();
            }

            return RedirectToAction("Details", new { id = articleId });
        }

    }
}