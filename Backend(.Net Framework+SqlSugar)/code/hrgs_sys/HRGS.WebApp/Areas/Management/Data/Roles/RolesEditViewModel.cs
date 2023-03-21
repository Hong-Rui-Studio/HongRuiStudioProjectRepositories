using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace HRGS.WebApp.Areas.Management.Data.Roles
{
    public class RolesEditViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "身份名称")]
        public string Title { get; set; }
    }
}