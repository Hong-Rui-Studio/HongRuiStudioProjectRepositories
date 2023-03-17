using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    /// <summary>
    /// 版权信息
    /// </summary>
    public class Copyright : BaseEntity
    {
        [Required]
        [StringLength(50), Column(TypeName = "varchar(50)")]
        public string Title { get; set; }

        [Required]
        [StringLength(200), Column(TypeName = "varchar(200)")]
        public string Content { get; set; }

        [Required]
        [StringLength(50), Column(TypeName = "varchar(50)")]
        public string Logo { get; set; }

        [Required]
        [StringLength(50), Column(TypeName = "varchar(50)")]
        public string Images { get; set; }

        [Required]
        [StringLength(50), Column(TypeName = "varchar(50)")]
        public string Tel { get; set; }

        [Required]
        [StringLength(50), Column(TypeName = "varchar(50)")]
        public string Email { get; set; }

        [Required]
        [StringLength(50), Column(TypeName = "varchar(50)")]
        public string Fax { get; set; }

    }
}
