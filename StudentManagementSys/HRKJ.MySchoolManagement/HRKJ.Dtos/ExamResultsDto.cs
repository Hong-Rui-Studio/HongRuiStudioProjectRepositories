using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRKJ.Dtos
{
    public class ExamResultsDto
    {
        public int Id { get; set; }

        public int ExamsId { get; set; }

        public int StudentId { get; set; }

        public decimal Scores { get; set; }

        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }

    }
}
