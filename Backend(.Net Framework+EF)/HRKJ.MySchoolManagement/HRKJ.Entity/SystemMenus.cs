using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRKJ.Entity
{
    public class SystemMenus : BaseEntity
    {
        [Required]
        [StringLength(50), Column(TypeName = "nvarchar")]
        public string Title { get; set; }

        [Required]
        [StringLength(50), Column(TypeName = "nvarchar")]
        public string Link { get; set; }

        
        [StringLength(50), Column(TypeName = "nvarchar")]
        public string Icons { get; set; } = "";

        [Required]
        public int ParentId { get; set; }
    }
}
