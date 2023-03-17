﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
   /// <summary>
   /// 企业文化
   /// </summary>
    public class CompanyCultures : BaseEntity
    {
        [Required]
        [StringLength(50), Column(TypeName = "varchar(50)")]
        public string Title { get; set; }

        [Required]
        [StringLength(250), Column(TypeName = "varchar(500)")]
        public string Details { get; set; }
    }
}
