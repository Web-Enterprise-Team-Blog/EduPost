﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EduPost.Data;
using EduPost.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using File = EduPost.Models.File;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using System.IO.Compression;
using EduPost.Service;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.OutputCaching;
using EduPost.Models.ViewModels;

namespace EduPost.Controllers
{
    [Authorize]
    public class ArticlesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly NotificationHub _notificationHub;
		private readonly ReactionService _reactionService;
		private readonly IWebHostEnvironment _webHostEnvironment;

        public ArticlesController(ApplicationDbContext context, UserManager<User> userManager, NotificationHub notificationHub, ReactionService reactionService, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _userManager = userManager;
            _notificationHub = notificationHub;
            _reactionService = reactionService;
            _webHostEnvironment = webHostEnvironment;
        }

        private async Task SendNotification(string message)
        {
            await _notificationHub.Clients.All.SendAsync("SendNotification", message);
        }

        // GET: Articles
        public async Task<IActionResult> Index()
        {
            bool isAdmin = User.IsInRole("Admin");
            IEnumerable<Article> articles;

            if (isAdmin)
            {
                articles = await _context.Article.ToListAsync();
            }
            else
            {
                var userIdAsString = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (int.TryParse(userIdAsString, out int userId))
                {
                    articles = await _context.Article
                                              .Where(a => a.UserID == userId)
                                              .ToListAsync();
                    var sortedArticlesViewModel = new SortedArticlesViewModel
                    {
                        PendingArticles = articles.Where(a => a.StatusId == 0).OrderByDescending(a => a.CreatedDate),
                        AcceptedArticles = articles.Where(a => a.StatusId == 1).OrderByDescending(a => a.CreatedDate),
                        DeclinedArticles = articles.Where(a => a.StatusId == 2).OrderByDescending(a => a.CreatedDate),
                        ClosedArticles = articles.Where(a => a.StatusId == 3).OrderByDescending(a => a.CreatedDate)
                    };
                    return View(sortedArticlesViewModel);
                }
            }
            return View(new SortedArticlesViewModel());  
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

            if (article == null)
            {
                return NotFound();
            }
            return View(article);
        }

		[HttpGet]
		public async Task<IActionResult> GetUserReaction(int articleId)
		{
			try
			{
				var userIdAsString = _userManager.GetUserId(User);
				if (int.TryParse(userIdAsString, out int userId))
				{
					var reaction = await _reactionService.GetUserReaction(userId, articleId);

					if (reaction != null)
					{
						return Json(new { success = true, isLike = reaction.ReactionType });
					}
					else
					{
						return Json(new { success = true, message = "You have not reacted to this article before." });
					}
				}
				else
				{
					return Json(new { success = false, message = "Invalid user ID." });
				}
			}
			catch (Exception ex)
			{
				return Json(new { success = false, message = ex.Message });
			}
		}

		[HttpGet]
		public async Task<IActionResult> GetArticleReactionCounts(int articleId)
		{
			try
			{
				var likeCount = await _context.UserReaction
				   .Where(r => r.ArticleId == articleId && r.ReactionType)
				   .CountAsync();

				var dislikeCount = await _context.UserReaction
				   .Where(r => r.ArticleId == articleId && !r.ReactionType)
				   .CountAsync();

				return Json(new { success = true, likeCount = likeCount, dislikeCount = dislikeCount });
			}
			catch (Exception ex)
			{
				return Json(new { success = false, message = ex.Message });
			}
		}

		[HttpPost]
		public async Task<IActionResult> LikeOrDislikeArticle(int userId, int articleId, bool isLike)
		{
			try
			{
				await _reactionService.LikeOrDislikeArticle(userId, articleId, isLike);
				return Json(new { success = true });
			}
			catch (Exception ex)
			{
				return Json(new { success = false, message = ex.Message });
			}
		}


		[HttpPost]
		public async Task<IActionResult> LikeArticle(int articleId)
		{
			var userId = int.Parse(_userManager.GetUserId(User));
			await _reactionService.LikeArticle(userId, articleId);
			return RedirectToAction("Details", new { id = articleId });
		}

		[HttpPost]
		public async Task<IActionResult> DislikeArticle(int articleId)
		{
			var userId = int.Parse(_userManager.GetUserId(User));
			await _reactionService.DislikeArticle(userId, articleId);
			return RedirectToAction("Details", new { id = articleId });
		}

		// GET: Articles/Create
		[HttpGet]
        public IActionResult Create()
        {
            var article = new Article
            {
                Files = new List<File>()
            };

            try
            {
                var user = _userManager.GetUserAsync(User).Result;
                if (user != null)
                {
                    article.UserID = user.Id;
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error retrieving user information: {ex.Message}");
            }

            return View(article);
        }

        // POST: Articles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ArticleId,ArticleTitle,Files,AgreeToTerms,Description")] Article article, IFormFile[] files, ModelStateDictionary modelState)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (!article.AgreeToTerms)
                {
                    ModelState.AddModelError("AgreeToTerms", "You must agree to the Term and Conditions to create an article.");
                    return View(article);
                }
                if (files != null)
                {
                    foreach (var file in files)
                    {
                        if (file.Length > 0)
                        {
                            using (var ms = new MemoryStream())
                            {
                                await file.CopyToAsync(ms);
                                ms.Position = 0;

                                var fileToAdd = new File
                                {
                                    FileName = file.FileName,
                                    FileData = ms.ToArray(),
                                    FileContentType = file.ContentType
                                };

                                string uploadFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                                if (!Directory.Exists(uploadFolder))
                                {
                                    Directory.CreateDirectory(uploadFolder);
                                }

                                string fileSavePath = Path.Combine(uploadFolder, file.FileName);
                                using (FileStream stream = new FileStream(fileSavePath, FileMode.Create))
                                {
                                    ms.Position = 0;
                                    ms.CopyTo(stream);
                                }

                                _context.File.Add(fileToAdd);
                                await _context.SaveChangesAsync();

                                article.Files.Add(fileToAdd);
                            }
                        }
                    }
                }

                article.Faculty = _userManager.GetUserAsync(User).Result.Faculty;
                article.CreatedDate = DateTime.Now;
                article.ExpireDate = DateTime.Now.AddDays(14);
                article.StatusId = 0;
                var userId = int.Parse(_userManager.GetUserId(User));
                article.UserID = userId;

                _context.Add(article);
                await _context.SaveChangesAsync();

                var message = $"User {_userManager.GetUserAsync(User).Result.UserName} has created a new article.";
                await _notificationHub.SendNotificationToCoordinator(message, article.Faculty);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error creating article: {ex.Message}");
                return View(article);
            }
        }

        // GET: Articles/Edit/5

        public async Task<IActionResult> Edit(int? id)
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


            var faculties = await _context.Faculty.ToListAsync();
            ViewData["Faculties"] = new SelectList(faculties, "FacultyName", "FacultyName");
            return View(article);

        }

        // POST: Articles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("ArticleId,ArticleTitle,Files,Description")] Article article, IFormFile[] files)
        {
            try
            {
                if (id != article.ArticleId)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        if (files != null)
                        {
                            foreach (var file in files)
                            {
                                if (file.Length > 0)
                                {
                                    using (var ms = new MemoryStream())
                                    {
                                        await file.CopyToAsync(ms);
                                        ms.Position = 0;

                                        var fileToAdd = new File
                                        {
                                            FileName = file.FileName,
                                            FileData = ms.ToArray(),
                                            FileContentType = file.ContentType,
                                            ArticleId = article.ArticleId
                                        };

                                        string uploadFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                                        if (!Directory.Exists(uploadFolder))
                                        {
                                            Directory.CreateDirectory(uploadFolder);
                                        }

                                        string fileSavePath = Path.Combine(uploadFolder, file.FileName);
                                        using (FileStream stream = new FileStream(fileSavePath, FileMode.Create))
                                        {
                                            ms.Position = 0;
                                            ms.CopyTo(stream);
                                        }

                                        _context.File.Add(fileToAdd);
                                        await _context.SaveChangesAsync();
                                    }
                                }
                            }
                        }

                        var existingArticle = await _context.Article.FindAsync(article.ArticleId);
                        if (existingArticle != null)
                        {
                            existingArticle.ArticleTitle = article.ArticleTitle;
                            existingArticle.Description = article.Description;

                            _context.Entry(existingArticle).State = EntityState.Modified;
                            await _context.SaveChangesAsync();


                            var message = $"User {_userManager.GetUserAsync(User).Result.UserName} has changed some contents in the article:\"{article.ArticleTitle}\".";
                            await _notificationHub.SendNotificationToCoordinator(message, article.Faculty);
                        }
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ArticleExists(article.ArticleId))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }

                    return RedirectToAction(nameof(Index));
                }

                return View(article);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error creating article: {ex.Message}");
                return View(article);
            }
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

			var reactions = await _context.UserReaction
		        .Where(ur => ur.ArticleId == id)
		        .ToListAsync();


            var message = $"User {_userManager.GetUserAsync(User).Result.UserName} has removed the article:\"{article.ArticleTitle}\".";
            await _notificationHub.SendNotificationToCoordinator(message, article.Faculty);


            _context.UserReaction.RemoveRange(reactions);

			_context.Article.Remove(article);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ActionName("DeleteFile")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteFileConfirmed(int id)
        {
            if (_context.File == null)
            {
                return Problem("Entity set 'EduPostContext.File'  is null.");
            }

            var file = await _context.File.FindAsync(id);

            if (file != null)
            {
                string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", file.FileName);
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }

                _context.File.Remove(file);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Edit), new { id = file.ArticleId });
        }

        private bool ArticleExists(int? id)
        {
          return (_context.Article?.Any(e => e.ArticleId == id)).GetValueOrDefault();
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
