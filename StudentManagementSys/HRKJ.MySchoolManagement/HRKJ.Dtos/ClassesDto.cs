using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRKJ.Dtos
{
    public class ClassesDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int GradesId { get; set; }

        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
