using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    /// <summary>
    /// 技术体系
    /// </summary>
    public class TechnicalSystem : BaseEntity
    {
        [Required]
        [Column(TypeName = "text")]
        public string Contents { get; set; }
    }
}
