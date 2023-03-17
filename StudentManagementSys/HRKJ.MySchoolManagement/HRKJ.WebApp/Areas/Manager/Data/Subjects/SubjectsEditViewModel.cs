using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRKJ.WebApp.Areas.Manager.Data.Subjects
{
    public class SubjectsEditViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "课程名称")]
        public string Title { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "所属年级编号")]
        public int GradesId { get; set; }

    }
}