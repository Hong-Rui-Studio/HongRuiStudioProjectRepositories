using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    /// <summary>
    /// 系统菜单
    /// </summary>
    public class SystemMenus : BaseEntity
    {
        [Required]
        [StringLength(50), Column(TypeName = "varchar(50)")]
        public string Title { get; set; }

        [Required]
        [StringLength(50), Column(TypeName = "varchar(50)")]
        public string Link { get; set; }

        [Required]
        [StringLength(50), Column(TypeName = "varchar(50)")]
        public string Icon { get; set; }

        [Required]
        public int ParentId { get; set; }
    }
}
