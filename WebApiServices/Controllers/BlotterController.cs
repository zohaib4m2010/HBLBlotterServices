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
    public class BlotterController : ApiController
    {
        // GET:   
        [HttpGet]
        public JsonResult<List<Models.SP_SBPBlotter_Result>> GetAllBlotterList(String BrCode, String DataType, String CurrentDate,bool LoadData)
        {
            //String BrCode = "02";
            EntityMapperBlotter<DataAccessLayer.SP_SBPBlotter_Result, Models.SP_SBPBlotter_Result> mapObj = new EntityMapperBlotter<DataAccessLayer.SP_SBPBlotter_Result, Models.SP_SBPBlotter_Result>();

            List<DataAccessLayer.SP_SBPBlotter_Result> blotterList = DAL.GetAllBlotterData(BrCode, DataType,CurrentDate,LoadData);
            List<Models.SP_SBPBlotter_Result> blotter = new List<Models.SP_SBPBlotter_Result>();
            foreach (var item in blotterList)
            {
                blotter.Add(mapObj.Translate(item));
            }
            return Json<List<Models.SP_SBPBlotter_Result>>(blotter);
        }

 


        // GET:   
        [HttpGet]
        public JsonResult<List<Models.SP_GETLatestBlotterDTLReportDayWise_Result>> GetLatestBlotterDTLReportDayWise(int BR, string StartDate, string EndDate)
        {

            EntityMapperBlotter<DataAccessLayer.SP_GETLatestBlotterDTLReportDayWise_Result, Models.SP_GETLatestBlotterDTLReportDayWise_Result> mapObj = new EntityMapperBlotter<DataAccessLayer.SP_GETLatestBlotterDTLReportDayWise_Result, Models.SP_GETLatestBlotterDTLReportDayWise_Result>();
            List<DataAccessLayer.SP_GETLatestBlotterDTLReportDayWise_Result> dalEmail = DAL.GetLatestBlotterDTLDayWise(BR,StartDate,EndDate);
            List<Models.SP_GETLatestBlotterDTLReportDayWise_Result> SumForEmail = new List<Models.SP_GETLatestBlotterDTLReportDayWise_Result>();
            foreach (var item in dalEmail)
            {
                SumForEmail.Add(mapObj.Translate(item));
            }
            return Json<List<Models.SP_GETLatestBlotterDTLReportDayWise_Result>>(SumForEmail);


        }

        // GET:   
        [HttpGet]
        public JsonResult<List<Models.SP_GETLatestBlotterDTLPerDayWise_Result>> GetLatestBlotterDTLPerDayWise(int BR, string StartDate)
        {

            EntityMapperBlotter<DataAccessLayer.SP_GETLatestBlotterDTLPerDayWise_Result, Models.SP_GETLatestBlotterDTLPerDayWise_Result> mapObj = new EntityMapperBlotter<DataAccessLayer.SP_GETLatestBlotterDTLPerDayWise_Result, Models.SP_GETLatestBlotterDTLPerDayWise_Result>();
            List<DataAccessLayer.SP_GETLatestBlotterDTLPerDayWise_Result> dalEmail = DAL.GetLatestBlotterDTLPerDayWise(BR, StartDate);
            List<Models.SP_GETLatestBlotterDTLPerDayWise_Result> SumForEmail = new List<Models.SP_GETLatestBlotterDTLPerDayWise_Result>();
            foreach (var item in dalEmail)
            {
                SumForEmail.Add(mapObj.Translate(item));
            }
            return Json<List<Models.SP_GETLatestBlotterDTLPerDayWise_Result>>(SumForEmail);

        }


        // GET:   
        [HttpGet]
        public JsonResult<Models.SP_GETLatestBlotterDTLReportDayWise_Result> GetLatestBlotterDTLReportForToday(int BR)
        {

            EntityMapperBlotter<DataAccessLayer.SP_GETLatestBlotterDTLReportForToday_Result, Models.SP_GETLatestBlotterDTLReportDayWise_Result> mapObj = new EntityMapperBlotter<DataAccessLayer.SP_GETLatestBlotterDTLReportForToday_Result, Models.SP_GETLatestBlotterDTLReportDayWise_Result>();
            DataAccessLayer.SP_GETLatestBlotterDTLReportForToday_Result dalEmail = DAL.GetLatestBlotterDTLForToday(BR);
            Models.SP_GETLatestBlotterDTLReportDayWise_Result SumForEmail = new Models.SP_GETLatestBlotterDTLReportDayWise_Result();
            
                SumForEmail = mapObj.Translate(dalEmail);
            
            return Json<Models.SP_GETLatestBlotterDTLReportDayWise_Result>(SumForEmail);


        }


        // GET:   
        [HttpGet]
        public JsonResult<Models.SBP_BlotterOpeningBalance> GetLatestOpeningBalaceForToday(int BR,string Date)
        {

            EntityMapperBlotter<DataAccessLayer.SP_GetOpeningBalance_Result, Models.SBP_BlotterOpeningBalance> mapObj = new EntityMapperBlotter<DataAccessLayer.SP_GetOpeningBalance_Result, Models.SBP_BlotterOpeningBalance>();
            DataAccessLayer.SP_GetOpeningBalance_Result dalEmail = DAL.GetOpeningBalance(BR,Convert.ToDateTime(Date));
            Models.SBP_BlotterOpeningBalance SumForEmail = new Models.SBP_BlotterOpeningBalance();

            SumForEmail = mapObj.Translate(dalEmail);

            return Json<Models.SBP_BlotterOpeningBalance>(SumForEmail);


        }

        // GET:   
        [HttpPost]
        public JsonResult<List<Models.SP_GetOPICSManualData_Result>> GetOPICSManualData(GetBlotterMnualDataParam BMDP)
        {

            List<Models.SP_GetOPICSManualData_Result> SumForEmail = new List<Models.SP_GetOPICSManualData_Result>();
            if (BMDP.Recon) {
                EntityMapperBlotter<DataAccessLayer.SP_ReconcileOPICSManualData_Result, Models.SP_GetOPICSManualData_Result> mapObj = new EntityMapperBlotter<DataAccessLayer.SP_ReconcileOPICSManualData_Result, Models.SP_GetOPICSManualData_Result>();
                List<DataAccessLayer.SP_ReconcileOPICSManualData_Result> dalEmail = DAL.ReconcileOPICSManualData(BMDP.BR, BMDP.DateFor);
                foreach (var item in dalEmail)
                {
                    SumForEmail.Add(mapObj.Translate(item));
                }
            }
            else
            {
                EntityMapperBlotter<DataAccessLayer.SP_GetOPICSManualData_Result, Models.SP_GetOPICSManualData_Result> mapObj = new EntityMapperBlotter<DataAccessLayer.SP_GetOPICSManualData_Result, Models.SP_GetOPICSManualData_Result>();
                List<DataAccessLayer.SP_GetOPICSManualData_Result> dalEmail = DAL.GetOPICSManualData(BMDP.BR, BMDP.DateFor, BMDP.Flag);
                foreach (var item in dalEmail)
                {
                    SumForEmail.Add(mapObj.Translate(item));
                }
            }
            return Json<List<Models.SP_GetOPICSManualData_Result>>(SumForEmail);


        }
    }
}
