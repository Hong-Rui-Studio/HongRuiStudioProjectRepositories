using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRKJ.WebApp.Areas.Manager.Data.Grades
{
    public class GradesAddViewModel
    {
       

        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "年级名称")]
        public string Title { get; set; }
    }
}