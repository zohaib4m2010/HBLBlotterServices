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
    
    public partial class BlotterSBP_Reserved
    {
        public int SNo { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<int> CRRFinconID { get; set; }
        public Nullable<decimal> ReservedBalance { get; set; }
        public Nullable<decimal> SBPBalanace { get; set; }
        public Nullable<decimal> BalanceDifference { get; set; }
        public string Note { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<int> CurID { get; set; }
        public Nullable<int> BR { get; set; }
        public Nullable<int> BID { get; set; }
        public string Flag { get; set; }
    }
}
