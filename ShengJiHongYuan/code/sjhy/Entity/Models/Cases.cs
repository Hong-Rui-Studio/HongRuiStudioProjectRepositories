using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    /// <summary>
    /// 案例展示
    /// </summary>
    public class Cases : BaseEntity
    {
        [Required]
        [StringLength(50), Column(TypeName = "varchar(50)")]
        public string Title { get; set; }

        [Required]
        [StringLength(50), Column(TypeName = "varchar(50)")]
        public string Images { get; set; }

        [Required]
        public int WebMenuId { get; set; }
    }
}
