using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    /// <summary>
    /// 产品优势详情
    /// </summary>
    public class ProductAdvantagesInfo : BaseEntity
    {
        [Required]
        [StringLength(50), Column(TypeName = "varchar(50)")]
        public string Title { get; set; }

        [Required]
        [StringLength(250), Column(TypeName = "varchar(500)")]
        public string Content { get; set; }

        [Required]
        [StringLength(50), Column(TypeName = "varchar(50)")]
        public string Images { get; set; }

        [Required]
        [StringLength(50), Column(TypeName = "varchar(50)")]
        public string IndexShowImg { get; set; }

        [Required]
        [StringLength(50), Column(TypeName = "varchar(50)")]
        public string IndexHideImg { get; set; }
    }
}
