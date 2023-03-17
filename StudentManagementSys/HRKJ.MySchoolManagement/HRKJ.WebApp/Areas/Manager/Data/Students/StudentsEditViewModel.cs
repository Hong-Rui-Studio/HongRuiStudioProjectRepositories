using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace HRKJ.WebApp.Areas.Manager.Data.Students
{
    public class StudentsEditViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "真实姓名")]
        public string RealName { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "出生日期")]
        public DateTime BornDate { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "性别")]
        public int Gender { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [EmailAddress(ErrorMessage = "{0}格式不正确")]
        [Display(Name = "邮件地址")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "联系电话")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "QQ号码")]
        public string QQNumber { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "微信号码")]
        public string WeChat { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "班级编号")]
        public int ClassesId { get; set; }
    }
}