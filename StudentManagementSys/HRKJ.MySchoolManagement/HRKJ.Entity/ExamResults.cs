using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRKJ.Entity
{
    public class ExamResults :BaseEntity
    {
        [Required]
        public int ExamId { get; set; }

        [Required]
        public int StudentId { get; set; }

        [Required]
        [Column(TypeName = "decimal")]
        public decimal Scores { get; set; }
    }
}
