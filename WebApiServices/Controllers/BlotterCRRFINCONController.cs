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
    public class BlotterCRRFINCONController : ApiController
    {
        // GET: BlotterCRRFINCON
        [HttpGet]
        public JsonResult<Models.SBP_BlotterCRRFINCON> GetBlotterCRRFINCON(int id)
        {
            EntitiyMapperBlotterCRRFINCON<DataAccessLayer.SBP_BlotterCRRFINCON, Models.SBP_BlotterCRRFINCON> mapObj = new EntitiyMapperBlotterCRRFINCON<DataAccessLayer.SBP_BlotterCRRFINCON, Models.SBP_BlotterCRRFINCON>();
            DataAccessLayer.SBP_BlotterCRRFINCON dalBlotterCRRFINCON = DAL.GetCRRFINCONItem(id);
            Models.SBP_BlotterCRRFINCON products = new Models.SBP_BlotterCRRFINCON();
            products = mapObj.Translate(dalBlotterCRRFINCON);
            return Json<Models.SBP_BlotterCRRFINCON>(products);
        }

        [HttpGet]
        public JsonResult<List<Models.SBP_BlotterCRRFINCONPeriods>> GetBlotterCRRFINCONPeriods(int BR)
        {
            EntitiyMapperBlotterCRRFINCONPeriods<DataAccessLayer.SP_GetCRRFINCONPeriods_Result, Models.SBP_BlotterCRRFINCONPeriods> mapObj = new EntitiyMapperBlotterCRRFINCONPeriods<DataAccessLayer.SP_GetCRRFINCONPeriods_Result, Models.SBP_BlotterCRRFINCONPeriods>();
            List <DataAccessLayer.SP_GetCRRFINCONPeriods_Result> dalBlotterCRRFINCONPeriods = DAL.GetAllBlotterCRRFINCONPeriods(BR);
            List <Models.SBP_BlotterCRRFINCONPeriods> products = new List<Models.SBP_BlotterCRRFINCONPeriods>();
            foreach (var item in dalBlotterCRRFINCONPeriods)
            {
                products.Add(mapObj.Translate(item));
            }
            return Json<List<Models.SBP_BlotterCRRFINCONPeriods>>(products);
        }

        [HttpGet]
        public JsonResult<List<Models.SBP_BlotterCRRFINCON>> GetAllBlotterCRRFINCON(int UserID, int BranchID, int CurID,int BR,string StartDate,string EndDate)
        {
            EntitiyMapperBlotterCRRFINCON<DataAccessLayer.SP_GetSBPBlotterCRRFINCON_Result, Models.SBP_BlotterCRRFINCON> mapObj = new EntitiyMapperBlotterCRRFINCON<DataAccessLayer.SP_GetSBPBlotterCRRFINCON_Result, Models.SBP_BlotterCRRFINCON>();

            List<DataAccessLayer.SP_GetSBPBlotterCRRFINCON_Result> blotterCRRFINCONList = DAL.GetAllBlotterCRRFINCON(UserID, BranchID, CurID,BR,StartDate,EndDate);
            List<Models.SBP_BlotterCRRFINCON> blotterCRRFINCON = new List<Models.SBP_BlotterCRRFINCON>();
            foreach (var item in blotterCRRFINCONList)
            {
                blotterCRRFINCON.Add(mapObj.Translate(item));
            }
            return Json<List<Models.SBP_BlotterCRRFINCON>>(blotterCRRFINCON);
        }
        [HttpPost]
        public bool InsertCRRFINCON(Models.SBP_BlotterCRRFINCON blotterCRRFINCON)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                blotterCRRFINCON.DemandTimeLiablitiesTotal = (blotterCRRFINCON.DemandTimeLiablities - blotterCRRFINCON.TimeLiablitiesOverOneYear);
                blotterCRRFINCON.DemandTimeLiablitiesTotalForCRR = (blotterCRRFINCON.DemandTimeLiablitiesTotal + blotterCRRFINCON.PreMatureDeposit);

                EntitiyMapperBlotterCRRFINCON<Models.SBP_BlotterCRRFINCON, DataAccessLayer.SBP_BlotterCRRFINCON> mapObj = new EntitiyMapperBlotterCRRFINCON<Models.SBP_BlotterCRRFINCON, DataAccessLayer.SBP_BlotterCRRFINCON>();
                DataAccessLayer.SBP_BlotterCRRFINCON CRRFINCONObj = new DataAccessLayer.SBP_BlotterCRRFINCON();
                CRRFINCONObj = mapObj.Translate(blotterCRRFINCON);
                status = DAL.InsertCRRFINCON(CRRFINCONObj);
            }
            return status;

        }


        [HttpPut]
        public bool UpdateCRRFINCON(Models.SBP_BlotterCRRFINCON blotterCRRFINCON)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                blotterCRRFINCON.DemandTimeLiablitiesTotal = (blotterCRRFINCON.DemandTimeLiablities - blotterCRRFINCON.TimeLiablitiesOverOneYear);
                blotterCRRFINCON.DemandTimeLiablitiesTotalForCRR = (blotterCRRFINCON.DemandTimeLiablitiesTotal + blotterCRRFINCON.PreMatureDeposit);
                EntitiyMapperBlotterCRRFINCON<Models.SBP_BlotterCRRFINCON, DataAccessLayer.SBP_BlotterCRRFINCON> mapObj = new EntitiyMapperBlotterCRRFINCON<Models.SBP_BlotterCRRFINCON, DataAccessLayer.SBP_BlotterCRRFINCON>();
                DataAccessLayer.SBP_BlotterCRRFINCON CRRFINCONObj = new DataAccessLayer.SBP_BlotterCRRFINCON();
                CRRFINCONObj = mapObj.Translate(blotterCRRFINCON);
                status = DAL.UpdateCRRFINCON(CRRFINCONObj);
            }
            return status;

        }

        [HttpDelete]
        public bool DeleteCRRFINCON(int id)
        {
            var status = DAL.DeleteCRRFINCON(id);
            return status;
        }
    }
}