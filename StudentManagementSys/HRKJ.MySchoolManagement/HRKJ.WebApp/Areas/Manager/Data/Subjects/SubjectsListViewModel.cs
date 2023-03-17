using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRKJ.WebApp.Areas.Manager.Data.Subjects
{
    public class SubjectsListViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string GradesTitle { get; set; }

        public string UpdateTime { get; set; }
    }
}