
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace HRKJ.Entity
{
    public class Copyright : BaseEntity
    {
        [StringLength(50), Column(TypeName = "nvarchar")]
        public string Title { get; set; }

        [StringLength(2000), Column(TypeName = "nvarchar")]
        public string Content { get; set; }

        [StringLength(50), Column(TypeName = "nvarchar")]
        public string Phone { get; set; }

        [StringLength(50), Column(TypeName = "nvarchar")]
        public string Tel { get; set; }

        [StringLength(50), Column(TypeName = "nvarchar")]
        public string Address { get; set; }

        [StringLength(50), Column(TypeName = "nvarchar")]
        public string Photo { get; set; }

        [StringLength(50), Column(TypeName = "nvarchar")]
        public string Images { get; set; }

        [StringLength(50), Column(TypeName = "nvarchar")]
        public string Logo { get; set; }

        [StringLength(50), Column(TypeName = "nvarchar")]
        public string SmallLogo { get; set; }

        [StringLength(2000), Column(TypeName = "nvarchar")]
        public string Remark1 { get; set; }

        [StringLength(2000), Column(TypeName = "nvarchar")]
        public string Remark2 { get; set; }

    }
}
