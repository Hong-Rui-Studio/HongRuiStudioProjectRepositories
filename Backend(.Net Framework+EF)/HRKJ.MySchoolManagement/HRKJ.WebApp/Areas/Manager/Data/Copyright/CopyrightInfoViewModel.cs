using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRKJ.WebApp.Areas.Manager.Data.Copyright
{
    public class CopyrightInfoViewModel
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Phone { get; set; }
        public string Tel { get; set; }
        public string Address { get; set; }
        public HttpPostedFileBase PhotoBase { get; set; }
        public string Photo { get; set; }
        public string Images { get; set; }
        public HttpPostedFileBase LogoBase { get; set; }
        public string Logo { get; set; }
        public string SmallLogo { get; set; }
        public string Remark1 { get; set; }
        public string Remark2 { get; set; }

    }
}