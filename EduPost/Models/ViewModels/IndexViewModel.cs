using System;
using System.Collections.Generic;

namespace EduPost.Models.ViewModels
{
    public class IndexViewModel
    {
        public IList<ArticlesPerFacultyViewModel> ArticlesPerFaculty { get; set; }
        public IList<ArticlesPerDayViewModel> ArticlesPerDay { get; set; }

        public IndexViewModel()
        {
            ArticlesPerFaculty = new List<ArticlesPerFacultyViewModel>();
            ArticlesPerDay = new List<ArticlesPerDayViewModel>();
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
}
