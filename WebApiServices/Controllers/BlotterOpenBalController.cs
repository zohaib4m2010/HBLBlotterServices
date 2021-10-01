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
    public class BlotterOpenBalController : ApiController
    {
        // GET: BlotterOpenBal

        [HttpGet]
        public JsonResult<Models.SBP_BlotterOpeningBalance> GetBlotterOpenBalById(int id)
        {
            EntityMapperBlotterOpenBal<DataAccessLayer.SBP_BlotterOpeningBalance, Models.SBP_BlotterOpeningBalance>
                mapObj = new EntityMapperBlotterOpenBal<DataAccessLayer.SBP_BlotterOpeningBalance, Models.SBP_BlotterOpeningBalance>();
            DataAccessLayer.SBP_BlotterOpeningBalance dalBlotterOpenBal = DAL.GetOpenBalItem(id);
            Models.SBP_BlotterOpeningBalance products = new Models.SBP_BlotterOpeningBalance();
            products = mapObj.Translate(dalBlotterOpenBal);
            return Json<Models.SBP_BlotterOpeningBalance>(products);
        }

        [HttpGet]
        public JsonResult<List<Models.SBP_BlotterOpeningBalance>> GetAllBlotterOpenBal(int UserID, int BranchID, int CurID, int BR, string dateVal)
        {
            EntityMapperBlotterOpenBal<DataAccessLayer.SP_GetAllOpeningBalance_Result, Models.SBP_BlotterOpeningBalance> mapObj = new EntityMapperBlotterOpenBal<DataAccessLayer.SP_GetAllOpeningBalance_Result, Models.SBP_BlotterOpeningBalance>();

            List<DataAccessLayer.SP_GetAllOpeningBalance_Result> blotterOpenBalList = DAL.GetAllBlotterOpenBal(UserID, BranchID, CurID, BR,dateVal);
            List<Models.SBP_BlotterOpeningBalance> blotterOpenBal = new List<Models.SBP_BlotterOpeningBalance>();
            foreach (var item in blotterOpenBalList)
            {
                blotterOpenBal.Add(mapObj.Translate(item));
            }
            return Json<List<Models.SBP_BlotterOpeningBalance>>(blotterOpenBal);
        }
        [HttpPost]
        public bool InsertOpenBal(Models.SBP_BlotterOpeningBalance blotterOpenBal)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                EntityMapperBlotterOpenBal<Models.SBP_BlotterOpeningBalance, DataAccessLayer.SBP_BlotterOpeningBalance> mapObj = new EntityMapperBlotterOpenBal<Models.SBP_BlotterOpeningBalance, DataAccessLayer.SBP_BlotterOpeningBalance>();
                DataAccessLayer.SBP_BlotterOpeningBalance OpenBalObj = new DataAccessLayer.SBP_BlotterOpeningBalance();
                OpenBalObj = mapObj.Translate(blotterOpenBal);
                status = DAL.InsertOpenBal(OpenBalObj);
            }
            return status;

        }


        [HttpPut]
        public bool UpdateOpenBal(Models.SBP_BlotterOpeningBalance blotterOpenBal)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                EntityMapperBlotterOpenBal<Models.SBP_BlotterOpeningBalance, DataAccessLayer.SBP_BlotterOpeningBalance> mapObj = new EntityMapperBlotterOpenBal<Models.SBP_BlotterOpeningBalance, DataAccessLayer.SBP_BlotterOpeningBalance>();
                DataAccessLayer.SBP_BlotterOpeningBalance OpenBalObj = new DataAccessLayer.SBP_BlotterOpeningBalance();
                OpenBalObj = mapObj.Translate(blotterOpenBal);
                status = DAL.UpdateOpenBal(OpenBalObj);
            }
            return status;

        }

        [HttpDelete]
        public bool DeleteOpenBal(int id)
        {
            var status = DAL.DeleteOpenBal(id);
            return status;
        }

    }
}
