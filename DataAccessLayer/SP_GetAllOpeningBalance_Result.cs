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
    
    public partial class SP_GetAllOpeningBalance_Result
    {
        public long Id { get; set; }
        public Nullable<decimal> OpenBalActual { get; set; }
        public Nullable<decimal> AdjOpenBal { get; set; }
        public Nullable<System.DateTime> BalDate { get; set; }
        public string DataType { get; set; }
        public int UserID { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public int BR { get; set; }
        public int BID { get; set; }
        public int CurID { get; set; }
        public string Flag { get; set; }
        public Nullable<decimal> EstimatedOpenBal { get; set; }
    }
}
