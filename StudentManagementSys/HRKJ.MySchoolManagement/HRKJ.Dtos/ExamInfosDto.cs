using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRKJ.Dtos
{
    public class ExamInfosDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ExamDate { get; set; }
        public string SubjectsId { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
