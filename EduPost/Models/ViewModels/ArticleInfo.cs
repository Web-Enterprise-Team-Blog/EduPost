namespace EduPost.Models.ViewModels
{
    public class ArticleInfo
    {
        public int? ArticleId { get; set; }
        public string ArticleTitle { get; set; }
        public string Faculty { get; set; }
        public string UserName { get; set; }
        public bool Public { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public int? StatusId { get; set; }
    }
}
