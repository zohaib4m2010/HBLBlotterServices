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
    public class BlotterTradeController : ApiController
    {
        // GET: BlotterTrade
        [HttpGet]
        public JsonResult<List<Models.SP_GETAllTransactionTitles_Result>> GetAllTradeTransactionTitles()
        {
            EntityMapperBlotterTrade<DataAccessLayer.SP_GETAllTradeTransactionTitles_Result, Models.SP_GETAllTransactionTitles_Result>
                mapObj = new EntityMapperBlotterTrade<DataAccessLayer.SP_GETAllTradeTransactionTitles_Result, Models.SP_GETAllTransactionTitles_Result>();

            List<DataAccessLayer.SP_GETAllTradeTransactionTitles_Result> blotterTradeList = DAL.GetAllTradeTransactionTitles();
            List<Models.SP_GETAllTransactionTitles_Result> blotterTrade = new List<Models.SP_GETAllTransactionTitles_Result>();
            foreach (var item in blotterTradeList)
            {
                blotterTrade.Add(mapObj.Translate(item));
            }
            return Json<List<Models.SP_GETAllTransactionTitles_Result>>(blotterTrade);
        }

        [HttpGet]
        public JsonResult<Models.SBP_BlotterTrade> GetBlotterTrade(int id)
        {
            EntityMapperBlotterTrade<DataAccessLayer.SBP_BlotterTrade, Models.SBP_BlotterTrade>
                mapObj = new EntityMapperBlotterTrade<DataAccessLayer.SBP_BlotterTrade, Models.SBP_BlotterTrade>();
            DataAccessLayer.SBP_BlotterTrade dalBlotterTrade = DAL.GetTradeItem(id);
            Models.SBP_BlotterTrade products = new Models.SBP_BlotterTrade();
            products = mapObj.Translate(dalBlotterTrade);
            return Json<Models.SBP_BlotterTrade>(products);
        }

        [HttpGet]
        public JsonResult<List<Models.SP_GetAll_SBPBlotterTrade_Result>> GetAllBlotterTrade(int UserID, int BranchID, int CurID,int BR, string DateVal)
        {
            EntityMapperBlotterTrade<DataAccessLayer.SP_GetAll_SBPBlotterTrade_Result, Models.SP_GetAll_SBPBlotterTrade_Result> mapObj = new EntityMapperBlotterTrade<DataAccessLayer.SP_GetAll_SBPBlotterTrade_Result, Models.SP_GetAll_SBPBlotterTrade_Result>();

            List<DataAccessLayer.SP_GetAll_SBPBlotterTrade_Result> blotterTradeList = DAL.GetAllBlotterTrade(UserID,BranchID,CurID,BR,DateVal);
            List<Models.SP_GetAll_SBPBlotterTrade_Result> blotterTrade = new List<Models.SP_GetAll_SBPBlotterTrade_Result>();
            foreach (var item in blotterTradeList)
            {
                blotterTrade.Add(mapObj.Translate(item));
            }
            return Json<List<Models.SP_GetAll_SBPBlotterTrade_Result>>(blotterTrade);
        }
        [HttpGet]
        public JsonResult<List<Models.SP_GetAll_SBPBlotterTrade_Dashboard_Result>> GetAllBlotterTradeDashboard(int UserID, int BranchID, int CurID, int BR, string DateVal)
        {
            EntityMapperBlotterTrade<DataAccessLayer.SP_GetAll_SBPBlotterTrade_Dashboard_Result, Models.SP_GetAll_SBPBlotterTrade_Dashboard_Result> mapObj = new EntityMapperBlotterTrade<DataAccessLayer.SP_GetAll_SBPBlotterTrade_Dashboard_Result, Models.SP_GetAll_SBPBlotterTrade_Dashboard_Result>();

            List<DataAccessLayer.SP_GetAll_SBPBlotterTrade_Dashboard_Result> blotterTradeList = DAL.GetAllBlotterTradeDashboard(UserID, BranchID, CurID, BR, DateVal);
            List<Models.SP_GetAll_SBPBlotterTrade_Dashboard_Result> blotterTrade = new List<Models.SP_GetAll_SBPBlotterTrade_Dashboard_Result>();
            foreach (var item in blotterTradeList)
            {
                blotterTrade.Add(mapObj.Translate(item));
            }
            return Json<List<Models.SP_GetAll_SBPBlotterTrade_Dashboard_Result>>(blotterTrade);
        }
        [HttpPost]
        public bool InsertTrade(Models.SBP_BlotterTrade blotterTrade)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                EntityMapperBlotterTrade<Models.SBP_BlotterTrade, DataAccessLayer.SBP_BlotterTrade> mapObj = new EntityMapperBlotterTrade<Models.SBP_BlotterTrade, DataAccessLayer.SBP_BlotterTrade>();
                DataAccessLayer.SBP_BlotterTrade TradeObj = new DataAccessLayer.SBP_BlotterTrade();
                TradeObj = mapObj.Translate(blotterTrade);
                status = DAL.InsertTrade(TradeObj);
            }
            return status;

        }


        [HttpPut]
        public bool UpdateTrade(Models.SBP_BlotterTrade blotterTrade)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                EntityMapperBlotterTrade<Models.SBP_BlotterTrade, DataAccessLayer.SBP_BlotterTrade> mapObj = new EntityMapperBlotterTrade<Models.SBP_BlotterTrade, DataAccessLayer.SBP_BlotterTrade>();
                DataAccessLayer.SBP_BlotterTrade TradeObj = new DataAccessLayer.SBP_BlotterTrade();
                TradeObj = mapObj.Translate(blotterTrade);
                status = DAL.UpdateTrade(TradeObj);
            }
            return status;

        }

        [HttpDelete]
        public bool DeleteTrade(int id)
        {
            var status = DAL.DeleteTrade(id);
            return status;
        }
    }
}