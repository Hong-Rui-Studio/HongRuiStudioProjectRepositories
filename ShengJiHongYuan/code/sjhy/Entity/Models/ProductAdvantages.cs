using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    /// <summary>
    /// 产品优势描述
    /// </summary>
    public class ProductAdvantages : BaseEntity
    {
        [Required]
        [StringLength(250), Column(TypeName = "varchar(500)")]
        public string Content { get; set; }
    }
}
