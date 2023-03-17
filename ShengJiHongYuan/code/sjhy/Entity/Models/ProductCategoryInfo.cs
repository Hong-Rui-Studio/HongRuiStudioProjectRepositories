using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    /// <summary>
    /// 产品配置详情
    /// </summary>
    public class ProductCategoryInfo : BaseEntity
    {
        [Required]
        [StringLength(50), Column(TypeName = "varchar(50)")]
        public string Title { get; set; }

        [Required]
        [Column(TypeName = "text")]
        public string Content1 { get; set; }

        [Required]
        [Column(TypeName = "text")]
        public string Content2 { get; set; }

        [Required]
        [StringLength(50), Column(TypeName = "varchar(50)")]
        public string Images1 { get; set; }

        [Required]
        [StringLength(50), Column(TypeName = "varchar(50)")]
        public string Images2 { get; set; }

        [Required]
        [StringLength(50), Column(TypeName = "varchar(50)")]
        public string Images3 { get; set; }

        [Required]
        [StringLength(250), Column(TypeName = "varchar(500)")]
        public string Remark { get; set; }
    }
}
