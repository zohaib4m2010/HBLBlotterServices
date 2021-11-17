using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiServices.Models
{
    public class SP_GetAll_SBPBlotterTrade_Dashboard_Result
    {
        public long SNo { get; set; }
        public string DataType { get; set; }
        public int TTID { get; set; }
        public string TransactionType { get; set; }
        public Nullable<System.DateTime> Trade_Date { get; set; }
        public string TradeCOde { get; set; }
        public Nullable<decimal> Trade_InFlow { get; set; }
        public Nullable<decimal> Trade_OutFLow { get; set; }
        public string Note { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public Nullable<int> BR { get; set; }
        public int BID { get; set; }
        public int CurID { get; set; }
        public string Flag { get; set; }
    }
}