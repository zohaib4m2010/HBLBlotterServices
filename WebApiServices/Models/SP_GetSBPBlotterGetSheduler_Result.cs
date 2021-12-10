using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiServices.Models
{
    public class SP_GetSBPBlotterGetSheduler_Result
    {
        public int SID { get; set; }
        public Nullable<bool> RegTimerStatus { get; set; }
        public string RegStartTime { get; set; }
        public string RegEndTime { get; set; }
        public string RegFreq { get; set; }
        public Nullable<bool> RegIsUpdated { get; set; }
        public Nullable<bool> RegIsRun { get; set; }
        public Nullable<bool> FwdTimerStatus { get; set; }
        public string FwdStartTime { get; set; }
        public string FwdEndTime { get; set; }
        public string FwdFreq { get; set; }
        public Nullable<bool> FwdIsUpdated { get; set; }
        public Nullable<bool> FwdIsRun { get; set; }

    }
}