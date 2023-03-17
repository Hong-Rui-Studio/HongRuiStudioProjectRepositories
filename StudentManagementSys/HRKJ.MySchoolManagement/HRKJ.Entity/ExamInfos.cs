using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRKJ.Entity
{
    public class ExamInfos : BaseEntity
    {
        [Required]
        [StringLength(50), Column(TypeName = "nvarchar")]
        public string Title { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime ExamDate { get; set; }

        [Required]
        [StringLength(255), Column(TypeName = "nvarchar")]
        public string SubjectsId { get; set; }
    }
}
