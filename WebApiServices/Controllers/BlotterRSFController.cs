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
    public class BlotterRSFController : ApiController
    {
        [HttpGet]
        public JsonResult<List<Models.BlotterRSFTT>> GetAllRsfTT(int BR,string Date)
        {
            EntityMapperBlotterRSF<DataAccessLayer.SP_GetAllRsfTTTBO_Result, Models.BlotterRSFTT>
                mapObj = new EntityMapperBlotterRSF<DataAccessLayer.SP_GetAllRsfTTTBO_Result, Models.BlotterRSFTT>();

            List<DataAccessLayer.SP_GetAllRsfTTTBO_Result> blotterRSFList = DAL.GetAllRSFTT(BR,Convert.ToDateTime(Date));
            List<Models.BlotterRSFTT> blotterRSF = new List<Models.BlotterRSFTT>();
            foreach (var item in blotterRSFList)
            {
                blotterRSF.Add(mapObj.Translate(item));
            }
            return Json<List<Models.BlotterRSFTT>>(blotterRSF);
        }

        [HttpGet]
        public JsonResult<List<Models.BlotterRSFTTDashboard>> GetAllRsfTTDashboard(int BR, string Date)
        {
            EntityMapperBlotterRSF<DataAccessLayer.SP_GetAllRsfTTTBO_Dashboard_Result, Models.BlotterRSFTTDashboard>
                mapObj = new EntityMapperBlotterRSF<DataAccessLayer.SP_GetAllRsfTTTBO_Dashboard_Result, Models.BlotterRSFTTDashboard>();

            List<DataAccessLayer.SP_GetAllRsfTTTBO_Dashboard_Result> blotterRSFList = DAL.GetAllRSFTT_Dasboard(BR, Convert.ToDateTime(Date));
            List<Models.BlotterRSFTTDashboard> blotterRSF = new List<Models.BlotterRSFTTDashboard>();
            foreach (var item in blotterRSFList)
            {
                blotterRSF.Add(mapObj.Translate(item));
            }
            return Json<List<Models.BlotterRSFTTDashboard>>(blotterRSF);
        }
    }
}
