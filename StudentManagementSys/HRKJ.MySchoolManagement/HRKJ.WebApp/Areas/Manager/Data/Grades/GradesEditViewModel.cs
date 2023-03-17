using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRKJ.WebApp.Areas.Manager.Data.Grades
{
    public class GradesEditViewModel
    {
        public int Id { get; set; }

       

        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "年级班号")]
        public string Title { get; set; }
    }
}