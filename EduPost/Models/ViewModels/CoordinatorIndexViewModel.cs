namespace EduPost.Models.ViewModels
{
    public class CoordinatorIndexViewModel
    {
        public string ArticleTitle { get; set; }
        public string UserID { get; set; }
        public bool Public { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<Notification> Notifications { get; set; }
        public List<Article> Articles { get; set; }
        public CoordinatorIndexViewModel()
        {
            Notifications = new List<Notification>();
        }
    }
}
