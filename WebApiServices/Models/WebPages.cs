using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiServices.Models
{
    public class WebPages
    {
        public int WPID { get; set; }
        public string PageName { get; set; }
        public string ControllerName { get; set; }
        public string DisplayName { get; set; }
        public string PageDescription { get; set; }
        public Nullable<bool> isActive { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public Nullable<int> BlotterType { get; set; }
    }
}