using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRKJ.WebApp.Areas.Manager.Data.Seos
{
    public class SeosListViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Keyword { get; set; }
        public string Description { get; set; }
        public string MenusTitle { get; set; }
        public string UpdateTime { get; set; }
    }
}