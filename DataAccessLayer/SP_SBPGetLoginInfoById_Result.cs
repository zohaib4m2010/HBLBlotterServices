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
    
    public partial class SP_SBPGetLoginInfoById_Result
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string RoleName { get; set; }
        public int BranchID { get; set; }
        public string BranchName { get; set; }
        public Nullable<bool> isConventional { get; set; }
        public Nullable<bool> isislamic { get; set; }
        public string UserExists { get; set; }
        public string DefaultPage { get; set; }
        public string BlotterType { get; set; }
        public Nullable<int> CurrencyID { get; set; }
        public string Pages { get; set; }
    }
}
