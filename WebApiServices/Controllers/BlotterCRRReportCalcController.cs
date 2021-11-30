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
    public class BlotterCRRReportCalcController : ApiController
    {
        // GET: BlotterClearing
        

        [HttpGet]
        public JsonResult<List<Models.SP_GETAll_MAX_BlotterCRRReportCalcSetup_Result>> GetAllBlotterCRR()
            {
            EntityMappeBlotterCRRReportCalcSetup<DataAccessLayer.SP_GETAll_MAX_BlotterCRRReportCalcSetup_Result, Models.SP_GETAll_MAX_BlotterCRRReportCalcSetup_Result> mapObj = new EntityMappeBlotterCRRReportCalcSetup<DataAccessLayer.SP_GETAll_MAX_BlotterCRRReportCalcSetup_Result, Models.SP_GETAll_MAX_BlotterCRRReportCalcSetup_Result>();
           
            List<DataAccessLayer.SP_GETAll_MAX_BlotterCRRReportCalcSetup_Result> blotterCRR = DAL.GetAllRecordCRRReportCalc();
            List<Models.SP_GETAll_MAX_BlotterCRRReportCalcSetup_Result> BlotterCRRReportCalcSetup = new List<Models.SP_GETAll_MAX_BlotterCRRReportCalcSetup_Result>();
            foreach (var item in blotterCRR)
            {
                BlotterCRRReportCalcSetup.Add(mapObj.Translate(item));
            }
            return Json<List<Models.SP_GETAll_MAX_BlotterCRRReportCalcSetup_Result>>(BlotterCRRReportCalcSetup);
        }

        [HttpPut]
        public bool UpdateBlotterCRRReport(Models.SBP_BlotterCRRReportCalcSetup BlotterCRRReportCalcSetup)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                EntityMappeBlotterCRRReportCalcSetup<Models.SBP_BlotterCRRReportCalcSetup, DataAccessLayer.SBP_BlotterCRRReportCalcSetup> mapObj = new EntityMappeBlotterCRRReportCalcSetup<Models.SBP_BlotterCRRReportCalcSetup, DataAccessLayer.SBP_BlotterCRRReportCalcSetup>();
                DataAccessLayer.SBP_BlotterCRRReportCalcSetup CRRObj = new DataAccessLayer.SBP_BlotterCRRReportCalcSetup();
                CRRObj = mapObj.Translate(BlotterCRRReportCalcSetup);
                status = DAL.UpdateSBP_BlotterCRRReportCalcSetup(CRRObj);
            }
            return status;

        }
        [HttpPost]
        public bool InsertSBP_BlotterCRRReportCalcSetup(Models.SBP_BlotterCRRReportCalcSetup SBP_BlotterCRRReportCalcSetup)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
               // EntityMappeBlotterCRRReportCalcSetup<Models.SBP_BlotterCRRReportCalcSetup, DataAccessLayer.SBP_BlotterCRRReportCalcSetup> mapObj = new EntityMappeBlotterCRRReportCalcSetup<Models.SBP_BlotterCRRReportCalcSetup, DataAccessLayer.SBP_BlotterCRRReportCalcSetup>();
                EntityMappeBlotterCRRReportCalcSetup<Models.SBP_BlotterCRRReportCalcSetup, DataAccessLayer.SBP_BlotterCRRReportCalcSetup> mapObj = new EntityMappeBlotterCRRReportCalcSetup<Models.SBP_BlotterCRRReportCalcSetup, DataAccessLayer.SBP_BlotterCRRReportCalcSetup>();
                DataAccessLayer.SBP_BlotterCRRReportCalcSetup CRRObj = new DataAccessLayer.SBP_BlotterCRRReportCalcSetup();
                CRRObj = mapObj.Translate(SBP_BlotterCRRReportCalcSetup);
                status = DAL.InsertSBP_BlotterCRRReportCalcSetup(CRRObj);
            }
            return status;

        }
    }
}