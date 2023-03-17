using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRKJ.WebApp.Areas.Manager.Data.ExamInfos
{
    public class ExamInfosListViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ExamDate { get; set; }

        public string SubjectsNames  { get; set; }

        public string UpdateTime { get; set; }
    }
}