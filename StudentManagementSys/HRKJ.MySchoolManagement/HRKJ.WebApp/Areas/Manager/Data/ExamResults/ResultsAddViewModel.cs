using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRKJ.WebApp.Areas.Manager.Data.ExamResults
{
    public class ResultsAddViewModel
    {
        public int ExamsId { get; set; }

        public int[] StudentList { get; set; }

        public decimal[] ScoresList { get; set; }
    }
}