using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace HRKJ.WebApp.App_Start
{
    public class PageConfig
    {
        public static int PageSize 
        {
            get 
            {
                var size = ConfigurationManager.AppSettings["GetPageSize"];
                return string.IsNullOrEmpty(size) ? 8 : int.Parse(size);
            }
        }
    }
}