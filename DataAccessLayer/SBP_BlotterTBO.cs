//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    
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
    
        public virtual Branches Branch { get; set; }
        public virtual Currency Currency { get; set; }
        public virtual SBP_LoginInfo SBP_LoginInfo { get; set; }
        public virtual SBP_BlotterTransactionTitles SBP_BlotterTransactionTitles { get; set; }
    }
}
