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
    public class BlotterReconBreakupsController : ApiController
    {
        [HttpGet]
        public JsonResult<List<Models.SP_GETAllTransactionTitles_Result>> GetAllRECONBreakupsTransactionTitles()
        {
            EntityMapperBlotterReconBreakups<DataAccessLayer.SP_GETAllRECONBreakupsTransactionTitles_Result, Models.SP_GETAllTransactionTitles_Result>
                mapObj = new EntityMapperBlotterReconBreakups<DataAccessLayer.SP_GETAllRECONBreakupsTransactionTitles_Result, Models.SP_GETAllTransactionTitles_Result>();

            List<DataAccessLayer.SP_GETAllRECONBreakupsTransactionTitles_Result> blotterRBList = DAL.GetAllReconBreakupsTransactionTitles();
            List<Models.SP_GETAllTransactionTitles_Result> blotterRB = new List<Models.SP_GETAllTransactionTitles_Result>();
            foreach (var item in blotterRBList)
            {
                blotterRB.Add(mapObj.Translate(item));
            }
            return Json<List<Models.SP_GETAllTransactionTitles_Result>>(blotterRB);
        }

        [HttpGet]
        public JsonResult<Models.SBP_BlotterReconBreakups> GetBlotterReconBreakupsById(int id)
        {
            EntityMapperBlotterReconBreakups<DataAccessLayer.SBP_BlotterReconBreakups, Models.SBP_BlotterReconBreakups>
                mapObj = new EntityMapperBlotterReconBreakups<DataAccessLayer.SBP_BlotterReconBreakups, Models.SBP_BlotterReconBreakups>();
            DataAccessLayer.SBP_BlotterReconBreakups dalBlotterRB = DAL.GetRBItem(id);
            Models.SBP_BlotterReconBreakups products = new Models.SBP_BlotterReconBreakups();
            products = mapObj.Translate(dalBlotterRB);
            return Json<Models.SBP_BlotterReconBreakups>(products);
        }

        [HttpGet]
        public JsonResult<List<Models.SP_GetAll_SBPBlotterReconBreakups_Results>> GetAllBlotterBreakups(int UserID, int BranchID, int CurID, int BR, string DateVal)
        {
            EntityMapperBlotterReconBreakups<DataAccessLayer.SP_GetAll_SBPBlotterReconBreakups_Result, Models.SP_GetAll_SBPBlotterReconBreakups_Results> mapObj = new EntityMapperBlotterReconBreakups<DataAccessLayer.SP_GetAll_SBPBlotterReconBreakups_Result, Models.SP_GetAll_SBPBlotterReconBreakups_Results>();

            List<DataAccessLayer.SP_GetAll_SBPBlotterReconBreakups_Result> blotterRBList = DAL.GetAllBlotterReconBreakups(UserID, BranchID, CurID, BR, DateVal);
            List<Models.SP_GetAll_SBPBlotterReconBreakups_Results> blotterRB = new List<Models.SP_GetAll_SBPBlotterReconBreakups_Results>();
            foreach (var item in blotterRBList)
            {
                blotterRB.Add(mapObj.Translate(item));
            }
            return Json<List<Models.SP_GetAll_SBPBlotterReconBreakups_Results>>(blotterRB);
        }
        [HttpPost]
        public bool InsertReconBreakups(Models.SBP_BlotterReconBreakups blotterRB)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                EntityMapperBlotterReconBreakups<Models.SBP_BlotterReconBreakups, DataAccessLayer.SBP_BlotterReconBreakups> mapObj = new EntityMapperBlotterReconBreakups<Models.SBP_BlotterReconBreakups, DataAccessLayer.SBP_BlotterReconBreakups>();
                DataAccessLayer.SBP_BlotterReconBreakups RBObj = new DataAccessLayer.SBP_BlotterReconBreakups();
                RBObj = mapObj.Translate(blotterRB);
                status = DAL.InsertReconBreakups(RBObj);
            }
            return status;

        }


        [HttpPut]
        public bool UpdateReconBreakups(Models.SBP_BlotterReconBreakups blotterRB)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                EntityMapperBlotterReconBreakups<Models.SBP_BlotterReconBreakups, DataAccessLayer.SBP_BlotterReconBreakups> mapObj = new EntityMapperBlotterReconBreakups<Models.SBP_BlotterReconBreakups, DataAccessLayer.SBP_BlotterReconBreakups>();
                DataAccessLayer.SBP_BlotterReconBreakups RBObj = new DataAccessLayer.SBP_BlotterReconBreakups();
                RBObj = mapObj.Translate(blotterRB);
                status = DAL.UpdateReconBreakups(RBObj);
            }
            return status;

        }

        [HttpDelete]
        public bool DeleteReconBreakups(int id)
        {
            var status = DAL.DeleteReconBreakups(id);
            return status;
        }

    }
}
