using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRKJ.WebApp.Areas.Manager.Data.Users
{
    public class UsersAddViewModel
    {
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
        [Display(Name = "电子邮件")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "联系电话")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "QQ号码")]
        public string QQNumBer { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "微信号码")]
        public string WeChat { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "身份编号")]
        public int RolesId { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "身份编号")]
        public string Pwd { get; set; }


        public HttpPostedFileBase Photo { get; set; }
        
       
    }
}