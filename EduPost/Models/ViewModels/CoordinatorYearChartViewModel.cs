namespace EduPost.Models.ViewModels
{
    public class CoordinatorYearChartViewModel
    {
        public string? YearTitle { get; set; }
        public IList<ArticlesByStatusViewModel> ArticlesByStatus { get; set; }
        public IList<ArticlesPerMonthViewModel> ArticlesPerMonth { get; set; }
        public IList<ApprovalRateViewModel> ApprovalRateOverTime { get; set; }
        public IList<TopContributorViewModel> TopContributors { get; set; }

        public CoordinatorYearChartViewModel()
        {
            ArticlesByStatus = new List<ArticlesByStatusViewModel>();
            ArticlesPerMonth = new List<ArticlesPerMonthViewModel>();
            ApprovalRateOverTime = new List<ApprovalRateViewModel>();
            TopContributors = new List<TopContributorViewModel>();
        }
    }
}
