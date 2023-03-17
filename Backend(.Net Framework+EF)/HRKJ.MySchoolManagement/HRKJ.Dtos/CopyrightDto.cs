using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRKJ.Dtos
{
    public class CopyrightDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Phone { get; set; }

        public string Tel { get; set; }

        public string Address { get; set; }

        public string Photo { get; set; }

        public string Images { get; set; }

        public string Logo { get; set; }

        public string SmallLogo { get; set; }

        public string Remark1 { get; set; }

        public string Remark2 { get; set; }

        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
