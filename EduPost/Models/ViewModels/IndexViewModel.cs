using System;
using System.Collections.Generic;

namespace EduPost.Models.ViewModels
{
    public class IndexViewModel
    {
        public string? YearTitle { get; set; }
        public IList<ArticlesPerFacultyViewModel> ArticlesPerFaculty { get; set; }
        public IList<ArticlesPerDayViewModel> ArticlesPerDay { get; set; }
        public IList<ArticlesByStatusViewModel> ArticlesByStatus { get; set; }
        public IList<ArticlesByFacultyViewModel> ArticlesByFaculty { get; set; }

        public IndexViewModel()
        {
            ArticlesPerFaculty = new List<ArticlesPerFacultyViewModel>();
            ArticlesPerDay = new List<ArticlesPerDayViewModel>();
            ArticlesByStatus = new List<ArticlesByStatusViewModel>();
            ArticlesByFaculty = new List<ArticlesByFacultyViewModel>();
        }
    }

    public class ArticlesPerFacultyViewModel
    {
        public string? Faculty { get; set; }
        public int Count { get; set; }
    }

    public class ArticlesPerDayViewModel
    {
        public DateTime Day { get; set; }
        public int Count { get; set; }
    }

    public class ArticlesByStatusViewModel
    {
        public string Status { get; set; }
        public int Count { get; set; }
    }

    public class ArticlesByFacultyViewModel
    {
        public string Faculty { get; set; }
        public int Pending { get; set; }
        public int Approved { get; set; }
        public int Declined { get; set; }
    }
}
