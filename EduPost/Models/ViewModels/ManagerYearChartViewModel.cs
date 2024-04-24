namespace EduPost.Models.ViewModels
{
    public class ManagerYearChartViewModel
    {
        public string? YearTitle { get; set; }
        public IList<ArticlesPerFacultyViewModel> ArticlesPerFaculty { get; set; }
        public IList<ArticlesPerMonthViewModel> ArticlesPerMonth { get; set; }
        public IList<ArticlesByStatusViewModel> ArticlesByStatus { get; set; }
        public IList<ArticlesByFacultyViewModel> ArticlesByFaculty { get; set; }

        public ManagerYearChartViewModel()
        {
            ArticlesPerFaculty = new List<ArticlesPerFacultyViewModel>();
            ArticlesPerMonth = new List<ArticlesPerMonthViewModel>();
            ArticlesByStatus = new List<ArticlesByStatusViewModel>();
            ArticlesByFaculty = new List<ArticlesByFacultyViewModel>();
        }
    }
}
