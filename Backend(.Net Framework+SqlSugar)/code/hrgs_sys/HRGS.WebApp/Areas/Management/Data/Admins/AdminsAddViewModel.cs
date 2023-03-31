using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRGS.WebApp.Areas.Management.Data.Admins
{
    public class AdminsAddViewModel
    {
        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "昵称")]
        public string NickName { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "出生日期")]
        public DateTime BornDate { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "性别")]
        public int Gender { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [EmailAddress(ErrorMessage = "{0}格式不正确")]
        [Display(Name = "邮件地址")]
        public string Email  { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "联系电话")]
        public string Tel { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(16,MinimumLength = 6 ,ErrorMessage = "{0}要求长度必须是6 ~ 16 位之间" )]
        [Display(Name = "联系电话")]
        public string Pwd { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "头像")]
        public string Photo { get; set; }

        public string Images { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "家庭住址")]
        public string Address { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "微信号")]
        public string WeChat{ get; set; }


        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "身份编号")]

        public Guid RolesId { get; set; }


    }
}