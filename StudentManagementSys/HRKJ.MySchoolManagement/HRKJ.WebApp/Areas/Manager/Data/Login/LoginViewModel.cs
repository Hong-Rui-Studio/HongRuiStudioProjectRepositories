using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRKJ.WebApp.Areas.Manager.Data.Login
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "{0}不能为空")]
        [EmailAddress(ErrorMessage = "{0}格式不正确")]
        [Display(Name = "邮箱地址")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(16,MinimumLength =6,ErrorMessage = "{0}长度不正确")]
        [Display(Name = "登入密码")]
        public string Pwd { get; set; }
    }
}