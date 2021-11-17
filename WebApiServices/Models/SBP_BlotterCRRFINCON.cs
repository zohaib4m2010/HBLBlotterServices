using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiServices.Models
{
    public class SBP_BlotterCRRFINCON
    {
        public long SNo { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<decimal> DemandTimeLiablities { get; set; }
        public Nullable<decimal> TimeLiablitiesOverOneYear { get; set; }
        public Nullable<decimal> DemandTimeLiablitiesTotal { get; set; }
        public Nullable<decimal> PreMatureDeposit { get; set; }
        public Nullable<decimal> DemandTimeLiablitiesTotalForCRR { get; set; }
        public Nullable<decimal> Penalty { get; set; }
        public Nullable<decimal> ExtraBenefits { get; set; }
        public Nullable<decimal> CRR1Requirement { get; set; }
        public Nullable<decimal> CRR2Requirement { get; set; }
        public Nullable<decimal> RequirementPenalty { get; set; }
        public Nullable<decimal> RequirementExtBenefit { get; set; }
        public Nullable<double> BalMaintAgainstPenalty { get; set; }
        public Nullable<double> BalMaintAgainstExtBenft { get; set; }
        public int UserID { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public int BR { get; set; }
        public int BID { get; set; }
        public int CurID { get; set; }
        public string Flag { get; set; }
        public Nullable<int> Calc1 { get; set; }
        public Nullable<int> Calc2 { get; set; }

    }
}