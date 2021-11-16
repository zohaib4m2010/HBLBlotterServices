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
    public class BlotterClearingController : ApiController
    {
        // GET: BlotterClearing
        [HttpGet]
        public JsonResult<List<Models.SP_GETAllTransactionTitles_Result>> GetAllClearingTransactionTitles()
        {
            EntityMapperBlotterClearing<DataAccessLayer.SP_GETAllClearingTransactionTitles_Result, Models.SP_GETAllTransactionTitles_Result>
                mapObj = new EntityMapperBlotterClearing<DataAccessLayer.SP_GETAllClearingTransactionTitles_Result, Models.SP_GETAllTransactionTitles_Result>();

            List<DataAccessLayer.SP_GETAllClearingTransactionTitles_Result> blotterClearingList = DAL.GetAllClearingTransactionTitles();
            List<Models.SP_GETAllTransactionTitles_Result> blotterClearing = new List<Models.SP_GETAllTransactionTitles_Result>();
            foreach (var item in blotterClearingList)
            {
                blotterClearing.Add(mapObj.Translate(item));
            }
            return Json<List<Models.SP_GETAllTransactionTitles_Result>>(blotterClearing);
        }

        [HttpGet]
        public JsonResult<Models.SBP_BlotterClearing> GetBlotterClearing(int id)
        {
            EntityMapperBlotterClearing<DataAccessLayer.SBP_BlotterClearing, Models.SBP_BlotterClearing> 
                mapObj = new EntityMapperBlotterClearing<DataAccessLayer.SBP_BlotterClearing, Models.SBP_BlotterClearing>();
            DataAccessLayer.SBP_BlotterClearing dalBlotterClearing = DAL.GetClearingItem(id);
            Models.SBP_BlotterClearing products = new Models.SBP_BlotterClearing();
            products = mapObj.Translate(dalBlotterClearing);
            return Json<Models.SBP_BlotterClearing>(products);
        }

        [HttpGet]
        public JsonResult<List<Models.SP_GetAll_SBPBlotterClearing_Result>> GetAllBlotterClearing(int UserID, int BranchID, int CurID,int BR, string DateVal)
        {
            EntityMapperBlotterClearing<DataAccessLayer.SP_GetAll_SBPBlotterClearing_Result, Models.SP_GetAll_SBPBlotterClearing_Result> mapObj = new EntityMapperBlotterClearing<DataAccessLayer.SP_GetAll_SBPBlotterClearing_Result, Models.SP_GetAll_SBPBlotterClearing_Result>();

            List<DataAccessLayer.SP_GetAll_SBPBlotterClearing_Result> blotterClearingList = DAL.GetAllBlotterClearing(UserID,BranchID,CurID,BR,DateVal);
            List<Models.SP_GetAll_SBPBlotterClearing_Result> blotterClearing = new List<Models.SP_GetAll_SBPBlotterClearing_Result>();
            foreach (var item in blotterClearingList)
            {
                blotterClearing.Add(mapObj.Translate(item));
            }
            return Json<List<Models.SP_GetAll_SBPBlotterClearing_Result>>(blotterClearing);
        }

        [HttpGet]
        public JsonResult<List<Models.SP_GetAll_SBPBlotterClearing_Dashboard_Result>> GetAllBlotterClearingDashboard(int UserID, int BranchID, int CurID, int BR, string DateVal)
        {
            EntityMapperBlotterClearing<DataAccessLayer.SP_GetAll_SBPBlotterClearing_DashBoard_Result, Models.SP_GetAll_SBPBlotterClearing_Dashboard_Result> mapObj = new EntityMapperBlotterClearing<DataAccessLayer.SP_GetAll_SBPBlotterClearing_DashBoard_Result, Models.SP_GetAll_SBPBlotterClearing_Dashboard_Result>();

            List<DataAccessLayer.SP_GetAll_SBPBlotterClearing_DashBoard_Result> blotterClearingList = DAL.GetAllBlotterClearingDashboard(UserID, BranchID, CurID, BR, DateVal);
            List<Models.SP_GetAll_SBPBlotterClearing_Dashboard_Result> blotterClearing = new List<Models.SP_GetAll_SBPBlotterClearing_Dashboard_Result>();
            foreach (var item in blotterClearingList)
            {
                blotterClearing.Add(mapObj.Translate(item));
            }
            return Json<List<Models.SP_GetAll_SBPBlotterClearing_Dashboard_Result>>(blotterClearing);
        }
        [HttpPost]
        public bool InsertClearing(Models.SBP_BlotterClearing blotterClearing)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                EntityMapperBlotterClearing<Models.SBP_BlotterClearing, DataAccessLayer.SBP_BlotterClearing> mapObj = new EntityMapperBlotterClearing<Models.SBP_BlotterClearing, DataAccessLayer.SBP_BlotterClearing>();
                DataAccessLayer.SBP_BlotterClearing ClearingObj = new DataAccessLayer.SBP_BlotterClearing();
                ClearingObj = mapObj.Translate(blotterClearing);
                status = DAL.InsertClearing(ClearingObj);
            }
            return status;

        }


        [HttpPut]
        public bool UpdateClearing(Models.SBP_BlotterClearing blotterClearing)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                EntityMapperBlotterClearing<Models.SBP_BlotterClearing, DataAccessLayer.SBP_BlotterClearing> mapObj = new EntityMapperBlotterClearing<Models.SBP_BlotterClearing, DataAccessLayer.SBP_BlotterClearing>();
                DataAccessLayer.SBP_BlotterClearing ClearingObj = new DataAccessLayer.SBP_BlotterClearing();
                ClearingObj = mapObj.Translate(blotterClearing);
                status = DAL.UpdateClearing(ClearingObj);
            }
            return status;

        }

        [HttpDelete]
        public bool DeleteClearing(int id)
        {
            var status = DAL.DeleteClearing(id);
            return status;
        }

    }
}