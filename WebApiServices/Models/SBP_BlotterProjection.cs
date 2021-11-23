using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiServices.Models
{
    public class SBP_BlotterProjection
    {
        public int SNO { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<int> CRRFinconID { get; set; }
        public Nullable<decimal> Proj_InFlow { get; set; }
        public Nullable<decimal> Proj_OutFlow { get; set; }


        public Nullable<decimal> Custy { get; set; }
        public Nullable<decimal> RSF_NBP { get; set; }

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