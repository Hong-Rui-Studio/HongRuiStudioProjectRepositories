using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace HRGS.Commons
{
    public class PageConfig
    {
        public static int PageSize 
        {
            get 
            {
                var number = ConfigurationManager.AppSettings["SetPageSize"];
                return string.IsNullOrEmpty(number) ? 8 : int.Parse(number);
            }
        }
    }
}
