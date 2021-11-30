using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiServices.Models
{
    public partial class SBP_BlotterCRRReportCalcSetup
    {
        public int ID { get; set; }
        public Nullable<double> CalcVal1 { get; set; }
        public Nullable<double> CalcVal2 { get; set; }
        public Nullable<bool> isActive { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public int UserID { get; set; }
        public Nullable<int> Calc { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
    }
}