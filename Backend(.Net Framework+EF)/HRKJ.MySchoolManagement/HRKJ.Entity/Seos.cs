
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace HRKJ.Entity
{
    public class Seos : BaseEntity
    {
        [Required]
        [StringLength(50), Column(TypeName = "nvarchar")]
        public string Title { get; set; }

        [Required]
        [StringLength(500), Column(TypeName = "nvarchar")]
        public string Keyword { get; set; }

        [Required]
        [StringLength(2000), Column(TypeName = "nvarchar")]
        public string Description { get; set; }

        [Required]
        public int MenusId { get; set; }

    }
}
