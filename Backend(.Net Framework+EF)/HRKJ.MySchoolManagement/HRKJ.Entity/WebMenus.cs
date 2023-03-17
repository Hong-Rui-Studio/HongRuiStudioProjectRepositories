
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace HRKJ.Entity
{
    public class WebMenus : BaseEntity
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
