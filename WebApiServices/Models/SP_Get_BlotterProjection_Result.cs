using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiServices.Models
{
    public class SP_Get_BlotterProjection_Result
    {
        public int sno { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<decimal> Proj_InFlow { get; set; }
        public Nullable<decimal> Proj_OutFlow { get; set; }

        public Nullable<decimal> Custy { get; set; }
        public Nullable<decimal> RSF_NBP { get; set; }

    }
}