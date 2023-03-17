using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRKJ.WebApp.Areas.Manager.Data.FriendLinks
{
    public class FriendLinksListViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public string IsShow { get; set; }
        public string UpdateTime { get; set; }
    }
}