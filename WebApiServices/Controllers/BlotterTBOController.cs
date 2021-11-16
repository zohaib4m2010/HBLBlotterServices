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
    public class BlotterTBOController : ApiController
    {
        [HttpGet]
        public JsonResult<List<Models.SP_GETAllTransactionTitles_Result>> GetAllTBOTransactionTitles()
        {
            EntitiyMapperBlotterTBO<DataAccessLayer.SP_GETAllTBOTransactionTitles_Result, Models.SP_GETAllTransactionTitles_Result> mapObj = new EntitiyMapperBlotterTBO<DataAccessLayer.SP_GETAllTBOTransactionTitles_Result, Models.SP_GETAllTransactionTitles_Result>();

            List<DataAccessLayer.SP_GETAllTBOTransactionTitles_Result> blotterTBOList = DAL.GetAllTBOTransactionTitles();
            List<Models.SP_GETAllTransactionTitles_Result> blotterTBO = new List<Models.SP_GETAllTransactionTitles_Result>();
            foreach (var item in blotterTBOList)
            {
                blotterTBO.Add(mapObj.Translate(item));
            }
            return Json<List<Models.SP_GETAllTransactionTitles_Result>>(blotterTBO);
        }

        [HttpGet]
        public JsonResult<Models.SBP_BlotterTBO> GetBlotterTBO(int id)
        {
            EntitiyMapperBlotterTBO<DataAccessLayer.SBP_BlotterTBO, Models.SBP_BlotterTBO> mapObj = new EntitiyMapperBlotterTBO<DataAccessLayer.SBP_BlotterTBO, Models.SBP_BlotterTBO>();
            DataAccessLayer.SBP_BlotterTBO dalBlotterTBO = DAL.GetTBOItem(id);
            Models.SBP_BlotterTBO products = new Models.SBP_BlotterTBO();
            products = mapObj.Translate(dalBlotterTBO);
            return Json<Models.SBP_BlotterTBO>(products);
        }
        [HttpGet]
        public JsonResult<List<Models.SP_GetAll_SBPBlotterTBO_Result>> GetAllBlotterTBO(int UserID, int BranchID, int CurID, int BR, string DateVal)
        {
            EntitiyMapperBlotterTBO<DataAccessLayer.SP_GetAll_SBPBlotterTBO_Result, Models.SP_GetAll_SBPBlotterTBO_Result> mapObj = new EntitiyMapperBlotterTBO<DataAccessLayer.SP_GetAll_SBPBlotterTBO_Result, Models.SP_GetAll_SBPBlotterTBO_Result>();

            List<DataAccessLayer.SP_GetAll_SBPBlotterTBO_Result> blotterTBOList = DAL.GetAllBlotterTBO(UserID,BranchID,CurID,BR,DateVal);
            List<Models.SP_GetAll_SBPBlotterTBO_Result> blotterTBO = new List<Models.SP_GetAll_SBPBlotterTBO_Result>();
            foreach (var item in blotterTBOList)
            {
                blotterTBO.Add(mapObj.Translate(item));
            }
            return Json<List<Models.SP_GetAll_SBPBlotterTBO_Result>>(blotterTBO);
        }
        [HttpGet]
        public JsonResult<List<Models.SP_GetAll_SBPBlotterTBO_Dashboard_Result>> GetAllBlotterTBODashboard(int UserID, int BranchID, int CurID, int BR, string DateVal)
        {
            EntitiyMapperBlotterTBO<DataAccessLayer.SP_GetAll_SBPBlotterTBO_DashBoard_Result, Models.SP_GetAll_SBPBlotterTBO_Dashboard_Result> mapObj = new EntitiyMapperBlotterTBO<DataAccessLayer.SP_GetAll_SBPBlotterTBO_DashBoard_Result, Models.SP_GetAll_SBPBlotterTBO_Dashboard_Result>();

            List<DataAccessLayer.SP_GetAll_SBPBlotterTBO_DashBoard_Result> blotterTBOList = DAL.GetAllBlotterTBODashboard(UserID, BranchID, CurID, BR, DateVal);
            List<Models.SP_GetAll_SBPBlotterTBO_Dashboard_Result> blotterTBO = new List<Models.SP_GetAll_SBPBlotterTBO_Dashboard_Result>();
            foreach (var item in blotterTBOList)
            {
                blotterTBO.Add(mapObj.Translate(item));
            }
            return Json<List<Models.SP_GetAll_SBPBlotterTBO_Dashboard_Result>>(blotterTBO);
        }
      
        [HttpPost]
        public bool InsertTBO(Models.SBP_BlotterTBO blotterTBO)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                EntitiyMapperBlotterTBO<Models.SBP_BlotterTBO, DataAccessLayer.SBP_BlotterTBO> mapObj = new EntitiyMapperBlotterTBO<Models.SBP_BlotterTBO, DataAccessLayer.SBP_BlotterTBO>();
                DataAccessLayer.SBP_BlotterTBO TBOObj = new DataAccessLayer.SBP_BlotterTBO();
                TBOObj = mapObj.Translate(blotterTBO);
                status = DAL.InsertTBO(TBOObj);
            }
            return status;

        }


        [HttpPut]
        public bool UpdateTBO(Models.SBP_BlotterTBO blotterTBO)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                EntitiyMapperBlotterTBO<Models.SBP_BlotterTBO, DataAccessLayer.SBP_BlotterTBO> mapObj = new EntitiyMapperBlotterTBO<Models.SBP_BlotterTBO, DataAccessLayer.SBP_BlotterTBO>();
                DataAccessLayer.SBP_BlotterTBO TBOObj = new DataAccessLayer.SBP_BlotterTBO();
                TBOObj = mapObj.Translate(blotterTBO);
                status = DAL.UpdateTBO(TBOObj);
            }
            return status;

        }

        [HttpDelete]
        public bool DeleteTBO(int id)
        {
            var status = DAL.DeleteTBO(id);
            return status;
        }

    }
}