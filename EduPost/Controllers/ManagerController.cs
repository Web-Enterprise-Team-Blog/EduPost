using EduPost.Data;
using EduPost.Models;
using EduPost.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO.Compression;

namespace EduPost.Controllers
{
    [Authorize(Roles = "Manager")]
    public class ManagerController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ManagerController(ApplicationDbContext context, UserManager<User> userManager, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _userManager = userManager;
            _webHostEnvironment = webHostEnvironment;
        }

        public ActionResult Index()
        {
            var articlesPerFaculty = _context.Article
                .GroupBy(a => a.Faculty)
                .Select(group => new ArticlesPerFacultyViewModel
                {
                    Faculty = group.Key,
                    Count = group.Count()
                })
                .ToList();

            var startDate = DateTimeOffset.Now.AddDays(-6);
            var articlesPerDay = _context.Article
                .Where(a => a.CreatedDate >= startDate)
                .GroupBy(a => a.CreatedDate.Value.Date)
                .Select(group => new ArticlesPerDayViewModel
                {
                    Day = group.Key,
                    Count = group.Count()
                })
                .ToList();

            var articlesByStatus = _context.Article
                 .GroupBy(a => a.StatusId)
                 .Select(group => new ArticlesByStatusViewModel
                 {
                     Status = group.Key == 0 ? "Pending" : (group.Key == 1 ? "Approved" : "Declined"),
                     Count = group.Count()
                 })
                 .ToList<ArticlesByStatusViewModel>();

            var articlesByFaculty = _context.Article
                .GroupBy(a => new { a.Faculty, a.StatusId })
                .Select(group => new ArticlesByFacultyViewModel
                {
                    Faculty = group.Key.Faculty,
                    Pending = group.Key.StatusId == 0 ? group.Count() : 0,
                    Approved = group.Key.StatusId == 1 ? group.Count() : 0,
                    Declined = group.Key.StatusId == 2 ? group.Count() : 0
                })
                .ToList();

            var model = new IndexViewModel
            {
                ArticlesPerFaculty = articlesPerFaculty,
                ArticlesPerDay = articlesPerDay,
                ArticlesByStatus = articlesByStatus,
                ArticlesByFaculty = articlesByFaculty
            };


            return View(model);
        }


        public async Task<IActionResult> Articles()
        {
            return _context.Role != null ?
                        View(await _context.Article.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Role'  is null.");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Article == null)
            {
                return NotFound();
            }

            var article = await _context.Article
                .Include(a => a.Files)
                .Include(a => a.FeedBacks)
                .FirstOrDefaultAsync(a => a.ArticleId == id);

            var userIds = article.FeedBacks.Select(c => c.UserId).Distinct();
            var users = await _context.Users
                .Where(u => userIds.Contains(u.Id))
                .ToDictionaryAsync(u => u.Id, u => u.UserName);

            ViewBag.Usernames = users;

            if (article == null)
            {
                return NotFound();
            }
            return View(article);
        }

        [HttpGet]
        public async Task<IActionResult> DownloadArticleFiles(int? id)
        {
            if (id == null || _context.Article == null)
            {
                return NotFound();
            }

            var article = await _context.Article
                .Include(a => a.Files)
                .FirstOrDefaultAsync(m => m.ArticleId == id);

            if (article == null || article.Files == null || !article.Files.Any())
            {
                return NotFound();
            }

            using (var memoryStream = new MemoryStream())
            { 
                using (var archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                {
                    foreach (var file in article.Files)
                    {
                        var zipEntry = archive.CreateEntry(file.FileName, CompressionLevel.Fastest);
                        using (var zipStream = zipEntry.Open())
                        {
                            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", file.FileName);
                            if (System.IO.File.Exists(filePath))
                            {
                                using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                                {
                                    await fileStream.CopyToAsync(zipStream);
                                }
                            }
                        }
                    }
                }

                memoryStream.Position = 0;

                return File(memoryStream.ToArray(), "application/zip", $"Article_{id}_Files.zip");
            }
        }
    }
}
