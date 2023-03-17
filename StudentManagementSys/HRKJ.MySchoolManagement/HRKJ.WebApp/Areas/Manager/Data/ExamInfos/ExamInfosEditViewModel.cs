using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRKJ.WebApp.Areas.Manager.Data.ExamInfos
{
    public class ExamInfosEditViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "考试标题")]
        public string Title { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "考试时间")]
        public DateTime ExamDate { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "考试知识点")]
        public string[] SubjectIdList { get; set; }
    }
}