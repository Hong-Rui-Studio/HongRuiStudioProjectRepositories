using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRKJ.WebApp.Areas.Manager.Data.Classes
{
    public class ClassesAddViewModel
    {
        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "班级名称")]
        public string Title { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "年级编号")]
        public int GradesId { get; set; }
    }
}