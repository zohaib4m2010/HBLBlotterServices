using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiServices.Models
{
    public class SP_GETLatestBlotterDTLPerDayWise_Result
    {
        public int Id { get; set; }
        public long CRRFinconId { get; set; }
        public Nullable<System.DateTime> ReportDate { get; set; }
        public string WeekDays { get; set; }
        public decimal KarachiTotal { get; set; }
        public decimal HyderabadTotal { get; set; }
        public decimal SukkurTotal { get; set; }
        public decimal LahoreTotal { get; set; }
        public decimal FaisalabadTotal { get; set; }
        public decimal GWalaTotal { get; set; }
        public decimal MultanTotal { get; set; }
        public decimal SialkotTotal { get; set; }
        public decimal Isalamabad { get; set; }
        public decimal PindiTotal { get; set; }
        public decimal PeshawarTotal { get; set; }
        public decimal BhawalpurTotal { get; set; }
        public decimal MuzafarbadTotal { get; set; }
        public decimal DIKhanTotal { get; set; }
        public decimal QuettaTotal { get; set; }
        public decimal GawadarTotal { get; set; }
        public decimal OtherTotal { get; set; }
        public decimal PakistanToTal { get; set; }
        public decimal PreBal { get; set; }
        public decimal CRR3PcrReq { get; set; }
        public decimal CRR5PcrReq { get; set; }
        public double BalMaintain3Pcr { get; set; }
        public double BalMaintain5Pcr { get; set; }
        public decimal Penalty { get; set; }
        public decimal AvgForRemDays { get; set; }
        public decimal ReserveSurplus { get; set; }
        public double Reserve { get; set; }
        public decimal CRR5PcrReqWithoutEB { get; set; }
        public Nullable<double> BalMaintAgainstExtBenft { get; set; }
        public Nullable<double> BalMaintAgainstPenalty { get; set; }
        public decimal ReservedSBP { get; set; }
        public decimal ReservedSBPDif { get; set; }
        public string Remarks { get; set; }
        public int BR { get; set; }
        public Nullable<System.DateTime> createDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
    }
}