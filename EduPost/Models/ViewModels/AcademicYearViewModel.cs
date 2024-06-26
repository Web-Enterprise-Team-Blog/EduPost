﻿namespace EduPost.Models.ViewModels
{
    public class AcademicYearViewModel
    {
        public string YearTitle { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ArticleCount { get; set; }
        public string? MostArticlesFaculty { get; set; }
        public string? MostApprovedArticlesFaculty { get; set; }
        public string? MostDeclinedArticlesFaculty { get; set; }
        public string? LeastArticlesFaculty { get; set; }
        public string? LeastApprovedArticlesFaculty { get; set; }
        public string? LeastDeclinedArticlesFaculty { get; set; }

        public string? TotalComment { get; set; }
        public string? TotalLike { get; set; }
        public string? TotalDisLike { get; set; }
        public string? TotalActiveUser { get; set; }
        public string? UserWithMostArticle { get; set; }
    }

}
