using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRKJ.WebApp.Areas.Manager.Data.Login
{
    public class LeftMenuListViewModel
    {
        public string Title { get; set; }

        public string Link { get; set; }

        public string Icon { get; set; }

        public List<LeftMenuListViewModel> SonList { get; set; } = new List<LeftMenuListViewModel>();
    }
}