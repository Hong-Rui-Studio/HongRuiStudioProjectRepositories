using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    /// <summary>
    /// 分店
    /// </summary>
    public class BranchStores:BaseEntity
    {
        [Required]
        [StringLength(50), Column(TypeName = "varchar(50)")]
        public string Title { get; set; }

        [Required]
        [StringLength(50), Column(TypeName = "varchar(50)")]
        public string StoreTitle { get; set; }

        [Required]
        [StringLength(50), Column(TypeName = "varchar(50)")]
        public string Address { get; set; }
    }
}
