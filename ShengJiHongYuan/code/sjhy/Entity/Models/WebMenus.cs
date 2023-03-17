using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    /// <summary>
    /// 网页导航
    /// </summary>
    public class WebMenus : BaseEntity
    {
        [Required]
        [StringLength(50), Column(TypeName = "varchar(50)")]
        public string Title { get; set; }

        [Required]
        [StringLength(50), Column(TypeName = "varchar(50)")]
        public string Link { get; set; }

        [Required]
        public int ParentId { get; set; }

        [Required]
        public int IsShowNav { get; set; }

        [Required]
        public int IsConvenient { get; set; }
    }
}
