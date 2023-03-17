using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace HRKJ.Entity
{
    public class Grades : BaseEntity
    {
        [Required]
        [StringLength(50), Column(TypeName = "nvarchar")]
        public string Title { get; set; }
    }
}
