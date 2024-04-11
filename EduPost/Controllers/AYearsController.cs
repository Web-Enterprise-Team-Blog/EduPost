using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EduPost.Data;
using EduPost.Models;
using Microsoft.AspNetCore.Authorization;

namespace EduPost.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AYearsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AYearsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AYears
        public async Task<IActionResult> Index()
        {
              return _context.AYear != null ? 
                          View(await _context.AYear.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.AYear'  is null.");
        }

        // GET: AYears/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AYear == null)
            {
                return NotFound();
            }

            var aYear = await _context.AYear
                .FirstOrDefaultAsync(m => m.YearId == id);
            if (aYear == null)
            {
                return NotFound();
            }

            return View(aYear);
        }

        // GET: AYears/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AYears/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("YearId,YearTitle,BeginDate,EndDate")] AYear aYear)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aYear);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aYear);
        }

        // GET: AYears/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AYear == null)
            {
                return NotFound();
            }

            var aYear = await _context.AYear.FindAsync(id);
            if (aYear == null)
            {
                return NotFound();
            }
            return View(aYear);
        }

        // POST: AYears/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("YearId,YearTitle,BeginDate,EndDate")] AYear aYear)
        {
            if (id != aYear.YearId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aYear);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AYearExists(aYear.YearId))
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
            return View(aYear);
        }

        // GET: AYears/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AYear == null)
            {
                return NotFound();
            }

            var aYear = await _context.AYear
                .FirstOrDefaultAsync(m => m.YearId == id);
            if (aYear == null)
            {
                return NotFound();
            }

            return View(aYear);
        }

        // POST: AYears/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AYear == null)
            {
                return Problem("Entity set 'ApplicationDbContext.AYear'  is null.");
            }
            var aYear = await _context.AYear.FindAsync(id);
            if (aYear != null)
            {
                _context.AYear.Remove(aYear);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AYearExists(int id)
        {
          return (_context.AYear?.Any(e => e.YearId == id)).GetValueOrDefault();
        }
    }
}
