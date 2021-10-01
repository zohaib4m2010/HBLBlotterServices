using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiServices.Models
{
    public class SP_SBPBlotter_Result
    {
        public Nullable<long> DealNo { get; set; }
        public string DataType { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> DealDate { get; set; }
        public Nullable<decimal> Inflow { get; set; }
        public Nullable<decimal> Outflow { get; set; }
        public Nullable<decimal> OpeningBalance { get; set; }
        public Nullable<int> Recon { get; set; }
    }
}
