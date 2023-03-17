using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRKJ.WebApp.Areas.Manager.Data.SystemMenus
{
    public class SystemMenusListViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Link { get; set; }
        public string Icons { get; set; }
        public string ParentTitle { get; set; }
        public string UpdateTime { get; set; }
    }
}