using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRKJ.WebApp.Areas.Manager.Data.ExamResults
{
    public class ExamResultsListViewModel
    {
        public int Id { get; set; }

        public string ExamTitle { get; set; }

        public string StudentsName { get; set; }

        public decimal Scores { get; set; }

        public string UpdateTime { get; set; }
    }
}