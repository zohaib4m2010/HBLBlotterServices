﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiServices.Classes
{
    public class SBP_WebApiResponse
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public dynamic Data { get; set; }

    }
}