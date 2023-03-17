using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRKJ.Entity
{
    public class Roles : BaseEntity
    {
        [Required]
        [StringLength(50),Column(TypeName = "nvarchar")]
        public string Title { get; set; }
    }
}
