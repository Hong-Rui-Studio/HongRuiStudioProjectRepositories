﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace HRKJ.WebApp.Areas.Manager.Data.WebMenus
{
    public class WebMenusAddViewModel
    {
        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "系统菜单名称")]
        public string Title { get; set; }
        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "系统菜单链接")]
        public string Link { get; set; }
        public string Icons { get; set; } = "";
        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "父级菜单编号")]
        public int ParentId { get; set; }
    }
}