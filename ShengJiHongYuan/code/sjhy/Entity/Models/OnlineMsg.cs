using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    /// <summary>
    /// 在线留言
    /// </summary>
    public class OnlineMsg : BaseEntity
    {
        [Required]
        [StringLength(50), Column(TypeName = "varchar(50)")]
        public string Title { get; set; }
        [Required]
        [StringLength(50), Column(TypeName = "varchar(50)")]
        public string Name { get; set; }

        [Required]
        [StringLength(50), Column(TypeName = "varchar(50)")]
        public string Tel { get; set; }
        [Required]
        [StringLength(250), Column(TypeName = "varchar(500)")]
        public string Content { get; set; }
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime MessageTime { get; set; }

        [Required]
        public int IsRead { get; set; }

     
        [StringLength(250), Column(TypeName = "varchar(500)")]
        public string Remark { get; set; }
    }
}
