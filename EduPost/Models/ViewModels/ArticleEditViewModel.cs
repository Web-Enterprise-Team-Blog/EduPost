namespace EduPost.Models.ViewModels
{
    public class ArticleEditViewModel
    {
        public Article Article { get; set; }

        public List<UploadedFile> UploadedFiles { get; set; }

        public int? FileId { get; set; }
    }
}
