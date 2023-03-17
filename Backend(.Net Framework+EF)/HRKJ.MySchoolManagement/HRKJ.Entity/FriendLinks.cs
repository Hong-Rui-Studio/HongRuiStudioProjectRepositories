
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace HRKJ.Entity
{
    public class FriendLinks :BaseEntity
    {
        [Required]
        [StringLength(50), Column(TypeName = "nvarchar")]
        public string Title { get; set; }

        [Required]
        [StringLength(2000), Column(TypeName = "varchar")]
        public string Link { get; set; }

        [Required]
        public int IsShow { get; set; }
    }
}
