using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRGS.WebApp.Areas.Management.Data.Roles
{
    public class RolesListViewModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string UpdateTime { get; set; }
    }
}