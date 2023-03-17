using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRKJ.WebApp.Areas.Manager.Data.UsersPermission
{
    public class DeleteUsersPermissionViewModel
    {
        [Required]
        public int RolesId { get; set; }
        [Required]
        public int[] SystemMenuId { get; set; }
    }
}