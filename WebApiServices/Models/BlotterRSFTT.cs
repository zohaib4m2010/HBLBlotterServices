using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiServices.Models
{
    public class BlotterRSFTT
    { 
        public string Description { get; set; }
        public Nullable<System.DateTime> TBO_Date { get; set; }
        public Nullable<decimal> TBO_InFlow { get; set; }
        public Nullable<decimal> TBO_OutFlow { get; set; }
        public long SNo { get; set; }
    }
}