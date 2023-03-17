using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    /// <summary>
    /// 联系我们
    /// </summary>
    public class Contacts : BaseEntity
    {
        [Required]
        [StringLength(50),Column(TypeName ="varchar(50)")]
        public string HotLine { get; set; }

        [Required]
        [StringLength(50), Column(TypeName = "varchar(50)")]
        public string Logo { get; set; }

        [Required]
        [StringLength(50), Column(TypeName = "varchar(50)")]
        public string Address { get; set; }

        [Required]
        [StringLength(50), Column(TypeName = "varchar(50)")]
        public string SubscribeQRCode { get; set; }

        [Required]
        [StringLength(50), Column(TypeName = "varchar(50)")]
        public string ServiceQRCode { get; set; }

        [Required]
        [StringLength(50), Column(TypeName = "varchar(50)")]
        public string Wechat { get; set; }

        [Required]
        [StringLength(50), Column(TypeName = "varchar(50)")]
        public string QQ { get; set; }

        [Required]
        [StringLength(50), Column(TypeName = "varchar(50)")]
        public string WangWang { get; set; }

        [Required]
        [StringLength(50), Column(TypeName = "varchar(50)")]
        public string NetWorkMarketing { get; set; }

        [Required]
        [StringLength(50), Column(TypeName = "varchar(50)")]
        public string Tel { get; set; }

        [Required]
        [StringLength(50), Column(TypeName = "varchar(50)")]
        public string AlterSales { get; set; }





    }
}
