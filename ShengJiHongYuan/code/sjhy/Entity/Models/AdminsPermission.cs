using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    /// <summary>
    /// 权限分配
    /// </summary>
    public class AdminsPermission : BaseEntity
    {
        [Required]
        public int RolesId { get; set; }

        [Required]
        public int SystemMenuId { get; set; }
    }
}
