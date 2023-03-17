using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRKJ.Entity
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime CreateTime { get; set; } = DateTime.Now;

        [Column(TypeName = "datetime")]
        public DateTime UpdateTime { get; set; } = DateTime.Now;
    }
}
