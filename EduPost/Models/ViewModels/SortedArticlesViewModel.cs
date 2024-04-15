namespace EduPost.Models.ViewModels
{
    public class SortedArticlesViewModel
    {
        public IEnumerable<Article> PendingArticles { get; set; }
        public IEnumerable<Article> AcceptedArticles { get; set; }
        public IEnumerable<Article> DeclinedArticles { get; set; }
        public IEnumerable<Article> ClosedArticles { get; set; }
    }
}
