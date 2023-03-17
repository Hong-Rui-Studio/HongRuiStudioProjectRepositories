
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    /// <summary>
    /// 轮播图片
    /// </summary>
    public class Banner : BaseEntity
    {
        [Required]
        [StringLength(50), Column(TypeName = "varchar(50)")]
        public string Title { get; set; }

        [Required]
        [StringLength(50), Column(TypeName = "varchar(50)")]
        public string Link { get; set; }

        [Required]
        [StringLength(50), Column(TypeName = "varchar(50)")]
        public string Images { get; set; }

        [Required]
        public int WebMenuId { get; set; }
    }
}
