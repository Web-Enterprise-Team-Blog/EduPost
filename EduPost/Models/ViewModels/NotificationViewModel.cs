namespace EduPost.Models.ViewModels
{
	public class NotificationViewModel
	{
		public IEnumerable<Notification> ReadNotifications { get; set; }
		public IEnumerable<Notification> UnreadNotifications { get; set; }
	}
}
