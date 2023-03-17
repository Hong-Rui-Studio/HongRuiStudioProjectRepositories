using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    /// <summary>
    /// 窗材类别
    /// </summary>
    public class WindowCategory : BaseEntity
    {
        [Required]
        [StringLength(50), Column(TypeName = "varchar(50)")]
        public string Title { get; set; }
    }
}
