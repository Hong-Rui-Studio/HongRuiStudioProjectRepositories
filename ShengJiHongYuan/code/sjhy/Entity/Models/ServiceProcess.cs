using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    /// <summary>
    /// 服务流程
    /// </summary>
    public class ServiceProcess : BaseEntity
    {
        [Required]
        [StringLength(2000), Column(TypeName = "varchar(2000)")]
        public string Content1 { get; set; }

        [Required]
        [StringLength(2000), Column(TypeName = "varchar(2000)")]
        public string Content2 { get; set; }

        [Required]
        [StringLength(2000), Column(TypeName = "varchar(2000)")]
        public string Content3 { get; set; }
    }
}
