using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using WebApiServices.Repository;

namespace WebApiServices.Controllers
{
    public class BlotterRTGSController : ApiController
    {
        // GET: BlotterRTGS
        [HttpGet]
        public JsonResult<List<Models.SP_GETAllTransactionTitles_Result>> GetAllRTGSTransactionTitles()
        {
            EntityMapperBlotterRTGS<DataAccessLayer.SP_GETAllRTGSTransactionTitles_Result, Models.SP_GETAllTransactionTitles_Result>
                mapObj = new EntityMapperBlotterRTGS<DataAccessLayer.SP_GETAllRTGSTransactionTitles_Result, Models.SP_GETAllTransactionTitles_Result>();

            List<DataAccessLayer.SP_GETAllRTGSTransactionTitles_Result> blotterRTGSList = DAL.GetAllRTGSTransactionTitles();
            List<Models.SP_GETAllTransactionTitles_Result> blotterRTGS = new List<Models.SP_GETAllTransactionTitles_Result>();
            foreach (var item in blotterRTGSList)
            {
                blotterRTGS.Add(mapObj.Translate(item));
            }
            return Json<List<Models.SP_GETAllTransactionTitles_Result>>(blotterRTGS);
        }

        [HttpGet]
        public JsonResult<Models.SBP_BlotterRTGS> GetBlotterRTGS(int id)
        {
            EntityMapperBlotterRTGS<DataAccessLayer.SBP_BlotterRTGS, Models.SBP_BlotterRTGS>
                mapObj = new EntityMapperBlotterRTGS<DataAccessLayer.SBP_BlotterRTGS, Models.SBP_BlotterRTGS>();
            DataAccessLayer.SBP_BlotterRTGS dalBlotterRTGS = DAL.GetRTGSItem(id);
            Models.SBP_BlotterRTGS products = new Models.SBP_BlotterRTGS();
            products = mapObj.Translate(dalBlotterRTGS);
            return Json<Models.SBP_BlotterRTGS>(products);
        }

        [HttpGet]
        public JsonResult<List<Models.SP_GetAll_SBPBlotterRTGS_Result>> GetAllBlotterRTGS(int UserID, int BranchID, int CurID, int BR, string DateVal)
        {
            EntityMapperBlotterRTGS<DataAccessLayer.SP_GetAll_SBPBlotterRTGS_Result, Models.SP_GetAll_SBPBlotterRTGS_Result> mapObj = new EntityMapperBlotterRTGS<DataAccessLayer.SP_GetAll_SBPBlotterRTGS_Result, Models.SP_GetAll_SBPBlotterRTGS_Result>();

            List<DataAccessLayer.SP_GetAll_SBPBlotterRTGS_Result> blotterRTGSList = DAL.GetAllBlotterRTGS(UserID, BranchID, CurID, BR,DateVal);
            List<Models.SP_GetAll_SBPBlotterRTGS_Result> blotterRTGS = new List<Models.SP_GetAll_SBPBlotterRTGS_Result>();
            foreach (var item in blotterRTGSList)
            {
                blotterRTGS.Add(mapObj.Translate(item));
            }
            return Json<List<Models.SP_GetAll_SBPBlotterRTGS_Result>>(blotterRTGS);
        }

        
             [HttpGet]
        public JsonResult<List<Models.SP_GetAll_SBPBlotterRTGS_Dashboard_Result>> GetAllBlotterRTGSDashboard(int UserID, int BranchID, int CurID, int BR, string DateVal)
        {
            EntityMapperBlotterRTGS<DataAccessLayer.SP_GetAll_SBPBlotterRTGS_Dashboard_Result, Models.SP_GetAll_SBPBlotterRTGS_Dashboard_Result> mapObj = new EntityMapperBlotterRTGS<DataAccessLayer.SP_GetAll_SBPBlotterRTGS_Dashboard_Result, Models.SP_GetAll_SBPBlotterRTGS_Dashboard_Result>();

            List<DataAccessLayer.SP_GetAll_SBPBlotterRTGS_Dashboard_Result> blotterRTGSList = DAL.GetAllBlotterRTGSDashboard(UserID, BranchID, CurID, BR, DateVal);
            List<Models.SP_GetAll_SBPBlotterRTGS_Dashboard_Result> blotterRTGS = new List<Models.SP_GetAll_SBPBlotterRTGS_Dashboard_Result>();
            foreach (var item in blotterRTGSList)
            {
                blotterRTGS.Add(mapObj.Translate(item));
            }
            return Json<List<Models.SP_GetAll_SBPBlotterRTGS_Dashboard_Result>>(blotterRTGS);
        }
        [HttpPost]
        public bool InsertRTGS(Models.SBP_BlotterRTGS blotterRTGS)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                EntityMapperBlotterRTGS<Models.SBP_BlotterRTGS, DataAccessLayer.SBP_BlotterRTGS> mapObj = new EntityMapperBlotterRTGS<Models.SBP_BlotterRTGS, DataAccessLayer.SBP_BlotterRTGS>();
                DataAccessLayer.SBP_BlotterRTGS RTGSObj = new DataAccessLayer.SBP_BlotterRTGS();
                RTGSObj = mapObj.Translate(blotterRTGS);
                status = DAL.InsertRTGS(RTGSObj);
            }
            return status;

        }


        [HttpPut]
        public bool UpdateRTGS(Models.SBP_BlotterRTGS blotterRTGS)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                EntityMapperBlotterRTGS<Models.SBP_BlotterRTGS, DataAccessLayer.SBP_BlotterRTGS> mapObj = new EntityMapperBlotterRTGS<Models.SBP_BlotterRTGS, DataAccessLayer.SBP_BlotterRTGS>();
                DataAccessLayer.SBP_BlotterRTGS RTGSObj = new DataAccessLayer.SBP_BlotterRTGS();
                RTGSObj = mapObj.Translate(blotterRTGS);
                status = DAL.UpdateRTGS(RTGSObj);
            }
            return status;

        }

        [HttpDelete]
        public bool DeleteRTGS(int id)
        {
            var status = DAL.DeleteRTGS(id);
            return status;
        }
    }
}
