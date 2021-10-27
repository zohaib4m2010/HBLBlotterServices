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
    
    public partial class Currency
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Currency()
        {
            this.SBP_BlotterCRRFINCON = new HashSet<SBP_BlotterCRRFINCON>();
            this.SBP_BlotterBai_Muajjal = new HashSet<SBP_BlotterBai_Muajjal>();
            this.SBP_BlotterBreakups = new HashSet<SBP_BlotterBreakups>();
            this.SBP_BlotterClearing = new HashSet<SBP_BlotterClearing>();
            this.SBP_BlotterCRRReportingCurrencyWise = new HashSet<SBP_BlotterCRRReportingCurrencyWise>();
            this.SBP_BlotterFundingRepo = new HashSet<SBP_BlotterFundingRepo>();
            this.SBP_BlotterImportExport = new HashSet<SBP_BlotterImportExport>();
            this.SBP_BlotterManualData = new HashSet<SBP_BlotterManualData>();
            this.SBP_BlotterOpeningBalance = new HashSet<SBP_BlotterOpeningBalance>();
            this.SBP_BlotterOpeningClosingBalanceDIfferential = new HashSet<SBP_BlotterOpeningClosingBalanceDIfferential>();
            this.SBP_BlotterRTGS = new HashSet<SBP_BlotterRTGS>();
            this.SBP_BlotterTBO = new HashSet<SBP_BlotterTBO>();
            this.SBP_BlotterTrade = new HashSet<SBP_BlotterTrade>();
            this.SBP_BlotterFundsTransfer = new HashSet<SBP_BlotterFundsTransfer>();
            this.UserCurrencyRelations = new HashSet<UserCurrencyRelation>();
            this.SBP_BlotterManualEstBalance = new HashSet<SBP_BlotterManualEstBalance>();
        }
    
        public int CID { get; set; }
        public string Symbol { get; set; }
        public string Currency1 { get; set; }
        public string Country { get; set; }
        public Nullable<bool> isActive { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SBP_BlotterCRRFINCON> SBP_BlotterCRRFINCON { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SBP_BlotterBai_Muajjal> SBP_BlotterBai_Muajjal { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SBP_BlotterBreakups> SBP_BlotterBreakups { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SBP_BlotterClearing> SBP_BlotterClearing { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SBP_BlotterCRRReportingCurrencyWise> SBP_BlotterCRRReportingCurrencyWise { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SBP_BlotterFundingRepo> SBP_BlotterFundingRepo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SBP_BlotterImportExport> SBP_BlotterImportExport { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SBP_BlotterManualData> SBP_BlotterManualData { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SBP_BlotterOpeningBalance> SBP_BlotterOpeningBalance { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SBP_BlotterOpeningClosingBalanceDIfferential> SBP_BlotterOpeningClosingBalanceDIfferential { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SBP_BlotterRTGS> SBP_BlotterRTGS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SBP_BlotterTBO> SBP_BlotterTBO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SBP_BlotterTrade> SBP_BlotterTrade { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SBP_BlotterFundsTransfer> SBP_BlotterFundsTransfer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserCurrencyRelation> UserCurrencyRelations { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SBP_BlotterManualEstBalance> SBP_BlotterManualEstBalance { get; set; }
    }
}
