using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiServices.Models
{
    public partial class SBP_BlotterTBO
    {
        public long SNo { get; set; }
        public int TTID { get; set; }
        public Nullable<System.DateTime> TBO_Date { get; set; }
        public string TBOCOde { get; set; }
        public Nullable<decimal> TBO_InFlow { get; set; }
        public Nullable<decimal> AdjTBO_InFlow { get; set; }
        public Nullable<decimal> TBO_OutFLow { get; set; }
        public Nullable<decimal> AdjTBO_OutFLow { get; set; }
        public string Note { get; set; }
        public int UserID { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public int BR { get; set; }
        public int BID { get; set; }
        public int CurID { get; set; }
        public string Flag { get; set; }
        public string DataType { get; set; }
        public string BankCode { get; set; }
    }
}