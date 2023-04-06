using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRGS.WebApp.Areas.Management.Data.Admins
{
    public class AdminsListViewModel
    {

        public Guid Id { get; set; }
        public string NickName { get; set; }
        public string BornDate { get; set; }

        public string Gender { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }
        public string Photo { get; set; }
        public string Images { get; set; }
        public string Address { get; set; }
        public string WeChat { get; set; }

        public string RolesName { get; set; }

        public string UpdateTime { get; set; }
    }
}