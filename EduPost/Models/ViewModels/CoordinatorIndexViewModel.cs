namespace EduPost.Models.ViewModels
{
    public class CoordinatorIndexViewModel
    {
        public List<ArticleInfo> Articles { get; set; }
        public List<Notification> Notifications { get; set; }

        public CoordinatorIndexViewModel()
        {
            Notifications = new List<Notification>();
        }
    }
}
