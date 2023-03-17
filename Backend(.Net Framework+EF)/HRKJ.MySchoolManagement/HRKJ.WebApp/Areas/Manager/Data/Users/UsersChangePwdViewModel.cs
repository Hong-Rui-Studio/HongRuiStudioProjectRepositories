using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace HRKJ.WebApp.Areas.Manager.Data.Users
{
    public class UsersChangePwdViewModel
    {
        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "用户编号")]
        public int Id { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "用户新的密码")]
        public string NewPwd { get; set; }
    }
}