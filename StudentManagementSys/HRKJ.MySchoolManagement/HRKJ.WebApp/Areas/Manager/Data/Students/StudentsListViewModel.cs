using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRKJ.WebApp.Areas.Manager.Data.Students
{
    public class StudentsListViewModel
    {
        public int Id { get; set; }
        public string RealName { get; set; }
        public string BornDate { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string QQNumber { get; set; }
        public string WeChat { get; set; }
        public string ClassTitle { get; set; }
        public string UpdateTime { get; set; }
    }
}