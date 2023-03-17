using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    /// <summary>
    /// Seo优化
    /// </summary>
    public class Seos : BaseEntity
    {
        [Required]
        [StringLength(50), Column(TypeName = "varchar(50)")]
        public string Title { get; set; }

        [Required]
        [StringLength(200), Column(TypeName = "varchar(200)")]
        public string Keyword { get; set; }

        [Required]
        [StringLength(500), Column(TypeName = "varchar(500)")]
        public string Description { get; set; }

        [Required]
        public int WebMenuId { get; set; }
    }
}
