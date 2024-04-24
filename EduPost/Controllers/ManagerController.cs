using EduPost.Data;
using EduPost.Models;
using EduPost.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
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

            var statusNames = new Dictionary<int, string>
            {
                { 0, "Pending" },
                { 1, "Approved" },
                { 2, "Declined" },
                { 3, "Expired" }
            };

            var articlesByStatus = _context.Article
                .GroupBy(a => a.StatusId)
                .ToList()
                .Select(group => new ArticlesByStatusViewModel
                {
                    Status = statusNames.ContainsKey(group.Key ?? -1) ? statusNames[group.Key ?? -1] : "Unknown",
                    Count = group.Count()
                }).ToList();

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
            if (_context.Role == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Role' is null.");
            }

            var articles = await _context.Article
                .Include(a => a.User) 
                .Select(a => new ArticleInfo
                {
                    ArticleId = a.ArticleId,
                    ArticleTitle = a.ArticleTitle,
                    Faculty = a.Faculty,
                    UserName = _context.User.Where(u => u.Id == a.UserID).Select(u => u.UserName).FirstOrDefault(),
                    Public = a.Public,
                    CreatedDate = a.CreatedDate.GetValueOrDefault().DateTime,
                    ExpireDate = a.ExpireDate.GetValueOrDefault().DateTime,
                    StatusId = a.StatusId
                }).ToListAsync();

            return View(articles);
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

            string img;
            if (article.Image != null)
            {
                img = Convert.ToBase64String(article.Image);
            }
            else
            {
                img = null;
            }
            ViewData["Image"] = img;

            if (article == null)
            {
                return NotFound();
            }
            return View(article);
        }

        public async Task<IActionResult> AcademicYears()
        {
            var academicYearsWithStatistics = await _context.AYear
                .Select(ay => new AcademicYearViewModel
                {
                    YearTitle = ay.YearTitle,
                    ArticleCount = _context.Article
                        .Count(a => a.CreatedDate.HasValue &&
                                    a.Ayear == ay.YearTitle),
                    MostArticlesFaculty = _context.Article
                        .Where(a => a.CreatedDate.HasValue &&
                                    a.Ayear == ay.YearTitle)
                        .GroupBy(a => a.Faculty)
                        .OrderByDescending(g => g.Count())
                        .Select(g => g.Key)
                        .FirstOrDefault(),
                    MostApprovedArticlesFaculty = _context.Article
                        .Where(a => a.StatusId == 1 &&
                                    a.CreatedDate.HasValue &&
                                    a.Ayear == ay.YearTitle)
                        .GroupBy(a => a.Faculty)
                        .OrderByDescending(g => g.Count())
                        .Select(g => g.Key)
                        .FirstOrDefault(),
                    MostDeclinedArticlesFaculty = _context.Article
                        .Where(a => a.StatusId == 2 &&
                                    a.CreatedDate.HasValue &&
                                    a.Ayear == ay.YearTitle)
                        .GroupBy(a => a.Faculty)
                        .OrderByDescending(g => g.Count())
                        .Select(g => g.Key)
                        .FirstOrDefault(),
                    LeastArticlesFaculty = _context.Article
                        .Where(a => a.CreatedDate.HasValue &&
                                    a.Ayear == ay.YearTitle)
                        .GroupBy(a => a.Faculty)
                        .OrderBy(g => g.Count())
                        .Select(g => g.Key)
                        .FirstOrDefault(),
                    LeastApprovedArticlesFaculty = _context.Article
                        .Where(a => a.StatusId == 1 &&
                                    a.CreatedDate.HasValue &&
                                    a.Ayear == ay.YearTitle)
                        .GroupBy(a => a.Faculty)
                        .OrderBy(g => g.Count())
                        .Select(g => g.Key)
                        .FirstOrDefault(),
                    LeastDeclinedArticlesFaculty = _context.Article
                        .Where(a => a.StatusId == 2 &&
                                    a.CreatedDate.HasValue &&
                                    a.Ayear == ay.YearTitle)
                        .GroupBy(a => a.Faculty)
                        .OrderBy(g => g.Count())
                        .Select(g => g.Key)
                        .FirstOrDefault(),

                    TotalComment = _context.Article.Include(a => a.Comments)
                                    .Where(a => a.Ayear == ay.YearTitle && a.CreatedDate.HasValue)
                                    .SelectMany(a => a.Comments).Count().ToString(),

                    TotalLike = _context.Article.Include(a => a.UserReactions)
                                    .Where(a => a.Ayear == ay.YearTitle && a.CreatedDate.HasValue)
                                    .SelectMany(a => a.UserReactions).Where(r => r.ReactionType == true).Count().ToString(),

                    TotalDisLike = _context.Article.Include(a => a.UserReactions)
                                    .Where(a => a.Ayear == ay.YearTitle && a.CreatedDate.HasValue)
                                    .SelectMany(a => a.UserReactions).Where(r => r.ReactionType == false).Count().ToString(),

                    TotalActiveUser = _context.User.Where(u => u.Article
                                    .Any(a => a.Ayear == ay.YearTitle && a.CreatedDate.HasValue))
                                    .Count().ToString(),

                    UserWithMostArticle = _context.User.FirstOrDefault(u => u.Id == _context.Article
                                            .Where(a => a.Ayear == ay.YearTitle && a.CreatedDate.HasValue)
                                            .GroupBy(a => a.UserID)
                                            .OrderByDescending(g => g.Count())
                                            .Select(g => g.FirstOrDefault().UserID)
                                            .FirstOrDefault()).UserName,
                })
                .ToListAsync();

            return View(academicYearsWithStatistics);
        }

        public ActionResult YearChart(string yearTitle)
        {
            var articlesPerFaculty = _context.Article
                .Join(_context.AYear,
                      article => article.Ayear,
                      year => year.YearTitle,
                      (article, year) => new { Article = article, Year = year })
                .Where(join => join.Year.YearTitle == yearTitle)
                .GroupBy(join => join.Article.Faculty)
                .Select(group => new ArticlesPerFacultyViewModel
                {
                    Faculty = group.Key,
                    Count = group.Count()
                })
                .ToList();

            var startDate = DateTimeOffset.Now.AddMonths(-11);
            var endDate = DateTimeOffset.Now;

            var articlesPerMonth = _context.Article
                .Where(a => a.Ayear == yearTitle && a.CreatedDate.HasValue && a.CreatedDate.Value.Year == DateTimeOffset.Now.Year)
                .GroupBy(a => a.CreatedDate.Value.Month)
                .Select(group => new ArticlesPerMonthViewModel
                {
                    Month = group.Key,
                    Count = group.Count()
                })
                .ToList();

            var statusNames = new Dictionary<int, string>
                {
                    { 0, "Pending" },
                    { 1, "Approved" },
                    { 2, "Declined" },
                    { 3, "Expired" }
                };

            var articlesByStatus = _context.Article
                .Join(_context.AYear,
                      article => article.Ayear,
                      year => year.YearTitle,
                      (article, year) => new { Article = article, Year = year })
                .Where(join => join.Year.YearTitle == yearTitle)
                .GroupBy(join => join.Article.StatusId)
                .ToList()
                .Select(group => new ArticlesByStatusViewModel
                {
                    Status = statusNames.ContainsKey(group.Key ?? -1) ? statusNames[group.Key ?? -1] : "Unknown",
                    Count = group.Count()
                }).ToList();

            var articlesByFaculty = _context.Article
                .Join(_context.AYear,
                      article => article.Ayear,
                      year => year.YearTitle,
                      (article, year) => new { Article = article, Year = year })
                .Where(join => join.Year.YearTitle == yearTitle)
                .GroupBy(join => new { join.Article.Faculty, join.Article.StatusId })
                .Select(group => new ArticlesByFacultyViewModel
                {
                    Faculty = group.Key.Faculty,
                    Pending = group.Key.StatusId == 0 ? group.Count() : 0,
                    Approved = group.Key.StatusId == 1 ? group.Count() : 0,
                    Declined = group.Key.StatusId == 2 ? group.Count() : 0
                })
                .ToList();

            var model = new ManagerYearChartViewModel
            {
                YearTitle = yearTitle,
                ArticlesPerFaculty = articlesPerFaculty,
                ArticlesPerMonth = articlesPerMonth,
                ArticlesByStatus = articlesByStatus,
                ArticlesByFaculty = articlesByFaculty
            };

            return View(model);
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
