using EduPost.Data;
using EduPost.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduPost.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var academicYearsWithStatistics = await _context.AYear
                .Select(ay => new AcademicYearViewModel
                {
                    YearTitle = ay.YearTitle,
                    BeginDate = ay.BeginDate,
                    EndDate = ay.EndDate,
                    ArticleCount = _context.Article
                        .Count(a => a.CreatedDate.HasValue &&
                                    a.CreatedDate.Value >= ay.BeginDate &&
                                    a.CreatedDate.Value <= ay.EndDate),
                    MostArticlesFaculty = _context.Article
                        .Where(a => a.CreatedDate.HasValue &&
                                    a.CreatedDate.Value >= ay.BeginDate &&
                                    a.CreatedDate.Value <= ay.EndDate)
                        .GroupBy(a => a.Faculty)
                        .OrderByDescending(g => g.Count())
                        .Select(g => g.Key)
                        .FirstOrDefault(),
                    MostApprovedArticlesFaculty = _context.Article
                        .Where(a => a.StatusId == 1 &&
                                    a.CreatedDate.HasValue &&
                                    a.CreatedDate.Value >= ay.BeginDate &&
                                    a.CreatedDate.Value <= ay.EndDate)
                        .GroupBy(a => a.Faculty)
                        .OrderByDescending(g => g.Count())
                        .Select(g => g.Key)
                        .FirstOrDefault(),
                    MostDeclinedArticlesFaculty = _context.Article
                        .Where(a => a.StatusId == 2 &&
                                    a.CreatedDate.HasValue &&
                                    a.CreatedDate.Value >= ay.BeginDate &&
                                    a.CreatedDate.Value <= ay.EndDate)
                        .GroupBy(a => a.Faculty)
                        .OrderByDescending(g => g.Count())
                        .Select(g => g.Key)
                        .FirstOrDefault(),
                    LeastArticlesFaculty = _context.Article
                        .Where(a => a.CreatedDate.HasValue &&
                                    a.CreatedDate.Value >= ay.BeginDate &&
                                    a.CreatedDate.Value <= ay.EndDate)
                        .GroupBy(a => a.Faculty)
                        .OrderBy(g => g.Count())
                        .Select(g => g.Key)
                        .FirstOrDefault(),
                    LeastApprovedArticlesFaculty = _context.Article
                        .Where(a => a.StatusId == 1 &&
                                    a.CreatedDate.HasValue &&
                                    a.CreatedDate.Value >= ay.BeginDate &&
                                    a.CreatedDate.Value <= ay.EndDate)
                        .GroupBy(a => a.Faculty)
                        .OrderBy(g => g.Count())
                        .Select(g => g.Key)
                        .FirstOrDefault(),
                    LeastDeclinedArticlesFaculty = _context.Article
                        .Where(a => a.StatusId == 2 &&
                                    a.CreatedDate.HasValue &&
                                    a.CreatedDate.Value >= ay.BeginDate &&
                                    a.CreatedDate.Value <= ay.EndDate)
                        .GroupBy(a => a.Faculty)
                        .OrderBy(g => g.Count())
                        .Select(g => g.Key)
                        .FirstOrDefault()
                })
                .ToListAsync();

            return View(academicYearsWithStatistics);
        }
    }
}
