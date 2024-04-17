using EduPost.Data;
using EduPost.Models;
using EduPost.Models.ViewModels;
using EduPost.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.IO.Compression;
using System.Security.Claims;
using System.Security.Cryptography;
using File = EduPost.Models.File;

namespace EduPost.Controllers
{
    [Authorize(Roles = "Coordinator")]
    public class CoordinatorController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly NotificationHub _notificationHub;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CoordinatorController(ApplicationDbContext context, UserManager<User> userManager, IWebHostEnvironment webHostEnvironment, NotificationHub notificationHub )
        {
            _context = context;
            _userManager = userManager;
            _notificationHub = notificationHub;
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

            var notifications = _context.Notification
                .Where(n => n.UserId == coordinator.Id)
                .OrderByDescending(n => n.Timestamp)
                .Take(5).
                ToList();

            var viewModel = new CoordinatorIndexViewModel
            {
                Articles = articles,
                Notifications = notifications
            };

            return View(viewModel);
        }


        public async Task<IActionResult> Articles()
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

        // GET: Articles/Details/5
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
            if(article.Image != null)
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
            var coordinator = await _userManager.GetUserAsync(User);
            var faculty = coordinator.Faculty;

            var academicYearsWithStatistics = await _context.AYear
                .Select(ay => new AcademicYearViewModel
                {
                    YearTitle = ay.YearTitle,
                    BeginDate = ay.BeginDate,
                    EndDate = ay.EndDate,
                    ArticleCount = _context.Article
                        .Count(a => a.CreatedDate.HasValue &&
                                    a.CreatedDate.Value >= ay.BeginDate &&
                                    a.CreatedDate.Value <= ay.EndDate &&
                                    a.Faculty == faculty),

                    MostApprovedArticlesFaculty = _context.Article
                        .Where(a => a.StatusId == 1 &&
                                    a.CreatedDate.HasValue &&
                                    a.CreatedDate.Value >= ay.BeginDate &&
                                    a.CreatedDate.Value <= ay.EndDate &&
                                    a.Faculty == faculty)
                        .Count().ToString(),

                    MostDeclinedArticlesFaculty = _context.Article
                        .Where(a => a.StatusId == 2 &&
                                    a.CreatedDate.HasValue &&
                                    a.CreatedDate.Value >= ay.BeginDate &&
                                    a.CreatedDate.Value <= ay.EndDate &&
                                    a.Faculty == faculty)
                        .Count().ToString(),

                    TotalComment = _context.Article.Include(a => a.Comments).Where(a =>
                                    a.CreatedDate.HasValue &&
                                    a.CreatedDate.Value >= ay.BeginDate &&
                                    a.CreatedDate.Value <= ay.EndDate &&
                                    a.Faculty == faculty)
                                    .SelectMany(a => a.Comments).Count().ToString(),

                    TotalLike = _context.Article.Include(a => a.UserReactions).Where(a =>
                                    a.CreatedDate.HasValue &&
                                    a.CreatedDate.Value >= ay.BeginDate &&
                                    a.CreatedDate.Value <= ay.EndDate &&
                                    a.Faculty == faculty)
                                    .SelectMany(a => a.UserReactions).Where(r => r.ReactionType == true).Count().ToString(),
                    TotalDisLike = _context.Article.Include(a => a.UserReactions).Where(a =>
                                    a.CreatedDate.HasValue &&
                                    a.CreatedDate.Value >= ay.BeginDate &&
                                    a.CreatedDate.Value <= ay.EndDate &&
                                    a.Faculty == faculty)
                                    .SelectMany(a => a.UserReactions).Where(r => r.ReactionType == false).Count().ToString(),

                    TotalActiveUser = _context.User.Where(u => u.Article
                                    .Any(a => a.CreatedDate.HasValue &&
                                    a.CreatedDate.Value >= ay.BeginDate &&
                                    a.CreatedDate.Value <= ay.EndDate &&
                                    a.Faculty == faculty))
                                    .Count().ToString(),

                    UserWithMostArticle = _context.User.FirstOrDefault(u => u.Id == _context.Article.Where(a =>
                                            a.CreatedDate.HasValue && a.CreatedDate.Value >= ay.BeginDate &&
                                            a.CreatedDate.Value <= ay.EndDate && a.Faculty == faculty)
                                            .GroupBy(a => a.UserID).OrderByDescending(g => g.Count())
                                            .Select(g => g.FirstOrDefault().UserID).FirstOrDefault()).UserName,
                })
                .ToListAsync();

            return View(academicYearsWithStatistics);
        }

        public async Task<string> GetUserFaculty()
        {
            var user = await _userManager.GetUserAsync(User);
            return user?.Faculty;
        }

        public async Task<ActionResult> Statistic()
        {
            string faculty = await GetUserFaculty();

            var statusNames = new Dictionary<int, string>
            {
                { 0, "Pending" },
                { 1, "Approved" },
                { 2, "Declined" },
                { 3, "Expired" }
            };

            var articlesByStatus = _context.Article
                .Where(a => a.Faculty == faculty)
                .GroupBy(a => a.StatusId)
                .ToList() 
                .Select(group => new ArticlesByStatusViewModel
                {
                    Status = statusNames.ContainsKey(group.Key ?? -1) ? statusNames[group.Key ?? -1] : "Unknown",
                    Count = group.Count()
                }).ToList();

            var articlesPerMonth = _context.Article
                .Where(a => a.Faculty == faculty && a.CreatedDate.HasValue && a.CreatedDate.Value.Year == DateTimeOffset.Now.Year)
                .ToList() 
                .GroupBy(a => a.CreatedDate.Value.Month)
                .Select(group => new ArticlesPerMonthViewModel
                {
                    Month = group.Key,
                    Count = group.Count()
                }).ToList();

            var approvalAndDeclineRatesOverTime = _context.Article
                .Where(a => a.Faculty == faculty && a.CreatedDate.HasValue)
                .GroupBy(a => a.CreatedDate.Value.Month)
                .Select(group => new
                {
                    Month = group.Key,
                    ApprovedCount = group.Count(a => a.StatusId == 1),
                    DeclinedCount = group.Count(a => a.StatusId == 2),
                    TotalCount = group.Count()
                })
                .Select(data => new ApprovalRateViewModel
                {
                    Month = data.Month,
                    ApprovalRate = (double)data.ApprovedCount / data.TotalCount,
                    DeclineRate = (double)data.DeclinedCount / data.TotalCount
                })
                .ToList();



            var articles = await _context.Article
                .Where(a => a.Faculty == faculty)
                .ToListAsync();

            var groupedArticles = articles
                .GroupBy(a => a.UserID)
                .OrderByDescending(group => group.Count())
                .Take(5)
                .ToList();

            var topContributors = new List<TopContributorViewModel>();
            foreach (var group in groupedArticles)
            {
                var userName = group.Key.HasValue ? (await _userManager.FindByIdAsync(group.Key.Value.ToString()))?.UserName : null;
                topContributors.Add(new TopContributorViewModel
                {
                    Contributor = userName,
                    Count = group.Count()
                });
            }


            var model = new StatisticViewModel
            {
                ArticlesByStatus = articlesByStatus,
                ArticlesPerMonth = articlesPerMonth,
                ApprovalRateOverTime = approvalAndDeclineRatesOverTime,
                TopContributors = topContributors
            };

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
                                              .ToListAsync();
            var model = new NotificationViewModel
            {
                ReadNotifications = notifications.Where(n => n.IsRead == true),
                UnreadNotifications = notifications.Where(n => n.IsRead == false || n.IsRead == null)
            };

            return View(model);
        }

		[HttpPost]
		public async Task<ActionResult> NotificationsDelete(int id)
		{
			var user = await _userManager.GetUserAsync(HttpContext.User);
			if (user == null)
			{
				return Content("User not found or not logged in.");
			}

			var userId = user.Id;

			var notificationToDelete = _context.Notification
				.FirstOrDefault(n => n.Id == id && n.UserId == userId && n.IsRead);

			if (notificationToDelete != null)
			{
				_context.Notification.Remove(notificationToDelete);
				_context.SaveChanges();
			}

			return RedirectToAction("Notifications");
		}

		[HttpPost]
		public async Task<ActionResult> NotificationsDeleteAll()
		{
			var user = await _userManager.GetUserAsync(HttpContext.User);
			if (user == null)
			{
				return Content("User not found or not logged in.");
			}

			var userId = user.Id;

			var notificationsToDelete = _context.Notification
				.Where(n => n.UserId == userId && n.IsRead)
				.ToList();

			if (notificationsToDelete.Any())
			{
				_context.Notification.RemoveRange(notificationsToDelete);
				_context.SaveChanges();
			}

			return RedirectToAction("Notifications");
		}

		public async Task<IActionResult> TogglePublic(int AID)
        {
            Article article = await _context.Article.FindAsync(AID);
            if(article == null)
            {
                throw new KeyNotFoundException();
            }
            if(article.Public == true)
            {
                article.Public = false;
                _context.Update(article);
                await _context.SaveChangesAsync();
                var message = $"Your article: \"{article.ArticleTitle}\" has been set to Private \"{_userManager.GetUserAsync(User).Result.UserName}\".";
                await _notificationHub.SendNotificationToUser(message, article.UserID);

            }
            else
            {
                article.Public = true;
                _context.Update(article);
                await _context.SaveChangesAsync();
                var message = $"Your article: \"{article.ArticleTitle}\" has been set to Public \"{_userManager.GetUserAsync(User).Result.UserName}\".";
                await _notificationHub.SendNotificationToUser(message, article.UserID);

            }
            return RedirectToAction(nameof(Details), new {id = AID});
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

        [HttpPost]
        public async Task<IActionResult> AddFeedback(int ArticleId, string Content)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized();
            }
            var feedback = new FeedBack
            {
                ArticleId = ArticleId,
                Content = Content,
                CreatedDate = DateTimeOffset.Now,
                UserId = user.Id 
            };

            _context.FeedBack.Add(feedback);
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", new { id = ArticleId });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteFeedback(int feedbackId)
        {
            var feedback = await _context.FeedBack.FindAsync(feedbackId);
            if (feedback == null)
            {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized();
            }

            if (feedback.UserId != user.Id)
            {
                return Forbid("You can delete only your own feedback!");
            }

            _context.FeedBack.Remove(feedback);
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", new { id = feedback.ArticleId });
        }

        public async Task<IActionResult> ApproveStatus(int articleId)
        {
            var article = await _context.Article.FindAsync(articleId);
            if (article != null)
            {
                article.StatusId = 1;
                await _context.SaveChangesAsync();
                var message = $"Your article: \"{article.ArticleTitle}\" has been Approved by coordinator \"{_userManager.GetUserAsync(User).Result.UserName}\".";
                await _notificationHub.SendNotificationToUser(message, article.UserID);
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
                var message = $"Your article: \"{article.ArticleTitle}\" has been Declined by coordinator \"{_userManager.GetUserAsync(User).Result.UserName}\".";
                await _notificationHub.SendNotificationToUser(message, article.UserID);
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

			var message = $"Your article: {article.ArticleTitle} has been Deleted.";
			await _notificationHub.SendNotificationToUser(message, article.UserID);
			_context.Article.Remove(article);

            await _context.SaveChangesAsync();

			return RedirectToAction(nameof(Index));
        }

        private bool ArticleExists(int? id)
        {
            return (_context.Article?.Any(e => e.ArticleId == id)).GetValueOrDefault();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>UpdateExpireDate(int articleid, DateTime expireDate)
        {
            try
            {
                var article = await _context.Article.FindAsync(articleid);

                if (article == null)
                {
                    return NotFound();
                }

                article.ExpireDate = expireDate;

                _context.Entry(article).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Details), new { id = articleid });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error updating expiration date: {ex.Message}");
                return View();
            }
        }


        [HttpPost]
        public IActionResult CheckExpiredArticles()
        {
            var articles = _context.Article
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

        public IActionResult ExtendDeadline(int articleId, DateTime deadlineDate)
        {
            var article = _context.Article.Find(articleId);
            if (article != null)
            {
                article.ExpireDate = deadlineDate;
                article.StatusId = 0;
                _context.SaveChanges();
            }

            return RedirectToAction("Details", new { id = articleId });
        }

    }
}