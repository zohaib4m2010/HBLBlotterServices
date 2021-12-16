using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using WebApiServices.Classes;
using WebApiServices.Models;
using WebApiServices.Repository;
using WebApiServices.TimerClass;

namespace WebApiServices.Controllers
{
    public class BlotterLoginController : ApiController
    {
        // GET:   
        [HttpPost]
        public string GetAllBlotterLogin(UserProfile up)
        {
            return Utilities.GetBlotterLogin(up.UserName, up.Password);
        }
        [HttpPost]
        public string GetAllBlotterLoginById(int id)
        {
            return Utilities.GetBlotterLoginById(id);
        }

        [HttpPost]
        public void SessionStart(SP_ADD_SessionStart SS)
        {

            DAL.SessionStart(SS.pSessionID, SS.pUserID, SS.pIP, SS.pLoginGUID, SS.pLoginTime, SS.pExpires);
        }



        [HttpPost]
        public void ActivityMonitor(SP_ADD_SessionStart SS)
        {

            DAL.ActivityMonitor(SS.pSessionID, SS.pUserID, SS.pIP, SS.pLoginGUID,SS.pData, SS.pActivity,SS.pURL);
        }

        [HttpPost]
        public void SessionStop(SP_ADD_SessionStart SS)
        {

            DAL.SessionStop(SS.pSessionID, SS.pUserID);
        }
    }
}
