using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRKJ.Entity
{
    public class Users : BaseEntity
    {
        [Required]
        [StringLength(50), Column(TypeName = "nvarchar")]
        public string RealName { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime BornDate { get; set; }

        [Required]
        public int Gender { get; set; }

        [Required]
        [StringLength(50), Column(TypeName = "nvarchar")]
        public string Email { get; set; }

        [Required]
        [StringLength(50), Column(TypeName = "nvarchar")]
        public string Phone { get; set; }

        [Required]
        [StringLength(50), Column(TypeName = "nvarchar")]
        public string Pwd { get; set; }

        [Required]
        [StringLength(50), Column(TypeName = "nvarchar")]
        public string QQNumber { get; set; }

        [Required]
        [StringLength(50), Column(TypeName = "nvarchar")]
        public string WeChat { get; set; }

        [Required]
        public int RolesId { get; set; }

        [Required]
        [StringLength(50), Column(TypeName = "nvarchar")]
        public string Photo { get; set; }

        [Required]
        [StringLength(50), Column(TypeName = "nvarchar")]
        public string Images { get; set; }

    }
}
