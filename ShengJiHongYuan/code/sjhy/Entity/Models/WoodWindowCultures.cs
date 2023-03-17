using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    /// <summary>
    /// 木窗文化
    /// </summary>
    public class WoodWindowCultures : BaseEntity
    {
        [Required]
        [Column(TypeName = "text")]
        public string Content { get; set; }
    }
}
