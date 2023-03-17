using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace HRKJ.WebApp.Areas.Manager.Data.FriendLinks
{
    public class FriendLinksAddViewModel
    {
        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "友情链接名称")]
        public string Title { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "友情链接路径")]
        public string Link { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "是否显示在页面")]
        public int IsShow { get; set; }
    }
}