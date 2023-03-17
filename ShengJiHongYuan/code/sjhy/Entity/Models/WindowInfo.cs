using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    /// <summary>
    /// 窗材详情
    /// </summary>
    public class WindowInfo : BaseEntity
    {
        [Required]
        [StringLength(50), Column(TypeName = "varchar(50)")]
        public string Title { get; set; }

        [Required]
        [StringLength(50), Column(TypeName = "varchar(50)")]
        public string ETitle { get; set; }

        [Required]
        [Column(TypeName = "text")]
        public string Content { get; set; }
    }
}
