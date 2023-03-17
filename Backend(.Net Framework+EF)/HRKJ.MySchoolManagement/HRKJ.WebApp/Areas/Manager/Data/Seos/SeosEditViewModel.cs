using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace HRKJ.WebApp.Areas.Manager.Data.Seos
{
    public class SeosEditViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "优化菜单名称")]
        public string Title { get; set; }
        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "优化关键字")]
        public string Keyword { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "优化描述")]
        public string Description { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "优化菜单编号")]
        public int WebMenusId { get; set; }
    }
}