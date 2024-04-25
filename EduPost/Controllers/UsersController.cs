using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EduPost.Data;
using EduPost.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace EduPost.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly ILogger<UsersController> _logger;

        public UsersController(ApplicationDbContext context, UserManager<User> userManager, RoleManager<Role> roleManager, ILogger<UsersController> logger)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;

        }

        // GET: Users
        [Authorize(Roles = "Admin, Manager, Coordinator")]
        public async Task<IActionResult> Index()
        {
            if (User.IsInRole("Admin"))
            {
                return _context.User != null ?
                        View(await _context.User.Where(u => u.Role != "Admin").ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.User'  is null.");
            }
            if (User.IsInRole("Manager"))
            {

                return _context.User != null ?
                        View(await _context.User.Where(u => u.Role == "Student").ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.User'  is null.");
            }
            if (User.IsInRole("Coordinator"))
            {
                User currentUser = await _userManager.GetUserAsync(User);
                return _context.User != null ?
                        View(await _context.User.Where(u => u.Role == "Student" && u.Faculty == currentUser.Faculty).ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.User'  is null.");
            }
            else
            {
                throw new UnauthorizedAccessException();
            }
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.User == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

       
        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserName,Email,FacultyId,RoleId,Id,NormalizedUserName,NormalizedEmail,EmailConfirmed,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] User user, string password)
        {
            if (ModelState.IsValid)
            {
                var result = await _userManager.CreateAsync(user, password);

                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(user);
        }

        // GET: Users/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.User == null)
            {
                return NotFound();
            }

            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var roles = await _roleManager.Roles.Where(r => r.Name != "Admin").ToListAsync();
            ViewData["Roles"] = new SelectList(roles, "Name", "Name");

            var faculties = await _context.Faculty.ToListAsync();
            ViewData["Faculties"] = new SelectList(faculties, "FacultyName", "FacultyName");

            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserName,Faculty,Role,Id")] User userInput)
        {
            _logger.LogInformation("Starting Edit operation for user ID: {UserId}", id);

            if (id != userInput.Id)
            {
                _logger.LogWarning("Edit operation failed: User ID mismatch. Expected {ExpectedId}, got {GotId}", id, userInput.Id);
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Edit operation aborted due to invalid model state for user ID: {UserId}. Errors: {ModelErrors}", id, ModelState);
                return View(userInput);
            }

            try
            {
                var userInDb = await _context.Users.FindAsync(id);
                if (userInDb == null)
                {
                    _logger.LogWarning("User with ID: {UserId} not found in database.", id);
                    return NotFound();
                }

                _logger.LogInformation("User found in database. Updating user details for user ID: {UserId}", id);
                _context.Entry(userInDb).CurrentValues.SetValues(userInput);

                var propertiesToNotModify = new string[]
                {
                    "PasswordHash", "SecurityStamp", "ConcurrencyStamp", "PhoneNumber",
                    "PhoneNumberConfirmed", "TwoFactorEnabled", "LockoutEnd", "LockoutEnabled",
                    "AccessFailedCount", "FirstLogin", "EmailConfirmed", "Email", "NormalizedEmail",
                    "NormalizedUserName", "Avatar"
                };

                foreach (var propName in propertiesToNotModify)
                {
                    _context.Entry(userInDb).Property(propName).IsModified = false;
                }

                var currentRoles = await _userManager.GetRolesAsync(userInDb);
                var newRoleName = userInput.Role;
                if (!currentRoles.Contains(newRoleName))
                {
                    var normalizedUserName = userInDb.NormalizedUserName;
                    await _userManager.RemoveFromRolesAsync(userInDb, currentRoles);
                    await _userManager.AddToRoleAsync(userInDb, newRoleName);
                    _logger.LogInformation("Role updated to {NewRole} for user ID: {UserId}", newRoleName, id);

                    userInDb.NormalizedUserName = normalizedUserName;
                }


                int changes = await _context.SaveChangesAsync();
                if (changes == 0)
                {
                    _logger.LogWarning("No changes detected by the database context for user ID: {UserId}", id);
                    throw new Exception("No changes were made to the database.");
                }

                _logger.LogInformation("Edit operation successful. Changes saved for user ID: {UserId}", id);
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _logger.LogError(ex, "Concurrency error occurred updating user ID: {UserId}", id);
                if (!UserExists(userInput.Id))
                {
                    return NotFound();
                }
                throw;
            }
            catch (Exception ex) when (ex is not DbUpdateConcurrencyException)
            {
                _logger.LogError(ex, "An error occurred while updating the user ID: {UserId}", id);
                ModelState.AddModelError(string.Empty, "An error occurred while updating the user.");
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Users/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.User == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.User == null)
            {
                return Problem("Entity set 'ApplicationDbContext.User'  is null.");
            }
            var user = await _context.User.FindAsync(id);
            if (user != null)
            {
                _context.User.Remove(user);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
          return (_context.User?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
