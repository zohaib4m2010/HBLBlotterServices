using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using WebApiServices.Models;
using WebApiServices.Repository;

namespace WebApiServices.Controllers
{
    public class BlotterLoginController : ApiController
    {
    
        // GET:   
        [HttpPost]
        public JsonResult<List<Models.SP_SBPGetLoginInfo_Result>> GetAllBlotterLogin(UserProfile up)
        {
            EntityMapperBlotterLogin<DataAccessLayer.SP_SBPGetLoginInfo_Result, Models.SP_SBPGetLoginInfo_Result> mapObj = 
                new EntityMapperBlotterLogin<DataAccessLayer.SP_SBPGetLoginInfo_Result, Models.SP_SBPGetLoginInfo_Result>();

            List<DataAccessLayer.SP_SBPGetLoginInfo_Result> blotterList = DAL.GetBlotterLogin( up.UserName,  up.Password);
            List<Models.SP_SBPGetLoginInfo_Result> blotter = new List<Models.SP_SBPGetLoginInfo_Result>();
            foreach (var item in blotterList)
            {
                blotter.Add(mapObj.Translate(item));
            }
            return Json<List<Models.SP_SBPGetLoginInfo_Result>>(blotter);
        }
        [HttpPost]
        public JsonResult<List<Models.SP_SBPGetLoginInfo_Result>> GetAllBlotterLoginById(int id)
        {
            EntityMapperBlotterLogin<DataAccessLayer.SP_SBPGetLoginInfoById_Result, Models.SP_SBPGetLoginInfo_Result> mapObj =
                new EntityMapperBlotterLogin<DataAccessLayer.SP_SBPGetLoginInfoById_Result, Models.SP_SBPGetLoginInfo_Result>();

            List<DataAccessLayer.SP_SBPGetLoginInfoById_Result> blotterList = DAL.GetBlotterLoginById(id);
            List<Models.SP_SBPGetLoginInfo_Result> blotter = new List<Models.SP_SBPGetLoginInfo_Result>();
            foreach (var item in blotterList)
            {
                blotter.Add(mapObj.Translate(item));
            }
            return Json<List<Models.SP_SBPGetLoginInfo_Result>>(blotter);
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
