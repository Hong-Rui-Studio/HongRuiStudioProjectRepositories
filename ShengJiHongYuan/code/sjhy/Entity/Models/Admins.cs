using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    /// <summary>
    /// 管理员
    /// </summary>
    public class Admins : BaseEntity
    {
        [Required]
        [StringLength(50), Column(TypeName = "varchar(50)")]
        public string Name { get; set; }

        [Required]
        [ Column(TypeName = "date")]
        public DateTime BornDate { get; set; }
        
        [Required]
        public int Gender { get; set; }

        [Required]
        [StringLength(50), Column(TypeName = "varchar(50)")]
        public string Email { get; set; }

        [Required]
        [StringLength(50), Column(TypeName = "varchar(50)")]
        public string Tel { get; set; }
        [Required]
        [StringLength(50), Column(TypeName = "varchar(50)")]
        public string Photo { get; set; }
        [Required]
        [StringLength(50), Column(TypeName = "varchar(50)")]
        public string Pwd { get; set; }

        [Required]
        public int RolesId { get; set; }




    }
}
