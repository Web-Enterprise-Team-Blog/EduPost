using System;
using System.Collections.Generic;

namespace EduPost.Models.ViewModels
{
    public class StatisticViewModel
    {
        public IList<ArticlesByStatusViewModel> ArticlesByStatus { get; set; }
        public IList<ArticlesPerMonthViewModel> ArticlesPerMonth { get; set; }
        public IList<ApprovalRateViewModel> ApprovalRateOverTime { get; set; }
        public IList<TopContributorViewModel> TopContributors { get; set; }

        public StatisticViewModel()
        {
            ArticlesByStatus = new List<ArticlesByStatusViewModel>();
            ArticlesPerMonth = new List<ArticlesPerMonthViewModel>();
            ApprovalRateOverTime = new List<ApprovalRateViewModel>();
            TopContributors = new List<TopContributorViewModel>();
        }
    }

    public class ArticlesPerMonthViewModel
    {
        public int Month { get; set; }
        public int Count { get; set; }
    }

    public class ApprovalRateViewModel
    {
        public int Month { get; set; }
        public double ApprovalRate { get; set; }
        public double DeclineRate { get; set; }
    }

    public class TopContributorViewModel
    {
        public string Contributor { get; set; }
        public int Count { get; set; }
    }
}
