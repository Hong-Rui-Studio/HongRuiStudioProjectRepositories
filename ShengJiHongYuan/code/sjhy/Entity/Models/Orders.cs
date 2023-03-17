using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    /// <summary>
    /// 在线下单
    /// </summary>
    public class Orders : BaseEntity
    {
        [Required]
        public int Hid { get; set; }
        [Required]
        public int HouseId { get; set; }
        [Required]
        public int StepId { get; set; }
        [Required]
        public int TypeId { get; set; }

        [Required]
        public int HouseTypeId { get; set; }

        [Required]
        public int AreaId { get; set; }

        [Required]
        [StringLength(50),Column(TypeName="varchar(50)")]
        public string Province { get; set; }

        [Required]
        [StringLength(50), Column(TypeName = "varchar(50)")]
        public string City { get; set; }

        [Required]
        [StringLength(50), Column(TypeName = "varchar(50)")]
        public string District { get; set; }

        [Required]
        [StringLength(50), Column(TypeName = "varchar(50)")]
        public string Address { get; set; }

        [Required]
        [StringLength(50), Column(TypeName = "varchar(50)")]
        public string Name { get; set; }

        [Required]
        [StringLength(50), Column(TypeName = "varchar(50)")]
        public string Tel { get; set; }
     
        [StringLength(500), Column(TypeName = "varchar(500)")]
        public string Remark { get; set; }

        [Required]
        public int IsRead { get; set; }


        [StringLength(500), Column(TypeName = "varchar(500)")]
        public string Explain { get; set; }

    }
}
