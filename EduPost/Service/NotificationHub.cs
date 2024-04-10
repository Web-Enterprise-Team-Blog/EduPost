using EduPost.Data;
using EduPost.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EduPost.Service
{
    public class NotificationHub : Hub
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public NotificationHub(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task SendNotificationToCoordinator(string message, string articleFaculty)
        {
            var coordinators = await _userManager.GetUsersInRoleAsync("Coordinator");
            var coordinatorsWithSameFaculty = coordinators.Where(c => c.Faculty == articleFaculty);

            foreach (var coordinator in coordinatorsWithSameFaculty)
            {
                var notification = new Notification
                {
                    Message = message,
                    Timestamp = DateTime.Now,
                    UserId = coordinator.Id
                };

                _context.Notification.Add(notification);
            }

            await _context.SaveChangesAsync();

            foreach (var coordinator in coordinatorsWithSameFaculty)
            {
                await Clients.User(coordinator.Id.ToString()).SendAsync("ReceiveNotification", message);
            }
        }

        public async Task SendNotificationToUser(string message, int? userId)
        {
            try
            {
                if (userId.HasValue)
                {
                    var user = await _context.User.FindAsync(userId.Value);
                    if (user != null)
                    {
                        var notification = new Notification
                        {
                            Message = message,
                            Timestamp = DateTime.Now,
                            UserId = user.Id
                        };

                        _context.Notification.Add(notification);
                        await _context.SaveChangesAsync();

                        // Ensure Clients is not null before attempting to send a notification
                        if (Clients != null)
                        {
                            await Clients.User(user.Id.ToString()).SendAsync("ReceiveNotification", message);
                        }
                        else
                        {
                            // Log a warning if Clients is null
                            Console.WriteLine("Warning: Clients is null in SendNotificationToUser method");
                        }
                    }
                    else
                    {
                        // Log a warning if user is null
                        Console.WriteLine($"Warning: User with ID {userId} not found");
                    }
                }
                else
                {
                    // Log a warning if userId is null
                    Console.WriteLine("Warning: userId is null in SendNotificationToUser method");
                }
            }
            catch (Exception ex)
            {
                // Log any exceptions that occur during the process
                Console.WriteLine($"An error occurred in SendNotificationToUser method: {ex.Message}");
            }
        }


        public override async Task OnConnectedAsync()
        {
            var user = Context.User;
            if (user.IsInRole("Coordinator"))
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, "Coordinators");
            }

            await base.OnConnectedAsync();
        }
    }
}
