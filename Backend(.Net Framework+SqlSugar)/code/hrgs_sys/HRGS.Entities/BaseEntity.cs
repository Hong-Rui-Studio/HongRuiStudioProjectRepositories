﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRGS.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();


        public DateTime CreateTime { get; set; } = DateTime.Now;

        public DateTime UpdateTime { get; set; } = DateTime.Now;


    }
}
