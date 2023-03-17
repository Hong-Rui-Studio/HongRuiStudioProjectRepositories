using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRKJ.Dtos
{
    public class StudentsDto
    {
        public int Id { get; set; }
        public string RealName { get; set; }
        public DateTime BornDate { get; set; }
        public int Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Pwd { get; set; }
        public string QQNumber { get; set; }
        public string WeChat { get; set; }
        public int ClassesId { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }

    }
}
