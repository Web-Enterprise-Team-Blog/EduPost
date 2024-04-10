using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using EduPost.Data;
using EduPost.Models;
using Microsoft.EntityFrameworkCore;

public class NotificationViewComponent : ViewComponent
{
    private readonly UserManager<User> _userManager; 
    private readonly ApplicationDbContext _context; 

    public NotificationViewComponent(UserManager<User> userManager, ApplicationDbContext context)
    {
        _userManager = userManager;
        _context = context;
    }

    public async Task<IViewComponentResult> InvokeAsync()
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
                                          .Take(5)
                                          .ToListAsync();
        return View(notifications);
    }
}
