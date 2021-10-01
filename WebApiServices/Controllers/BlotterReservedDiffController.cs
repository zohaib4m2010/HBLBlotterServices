using DataAccessLayer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Text;
using System.Web.Http.Results;
using WebApiServices.Models;
using WebApiServices.Repository;


namespace WebApiServices.Controllers
{
    public class BlotterReservedDiffController : ApiController
    {
        [HttpGet]
        public JsonResult<List<Models.SP_GetSBP_Reserved_Result>> GetAllblotterReserved(int UserID, int BranchID, int CurID, int BR)
        {
            EntitiyMapperBlotterReserved<DataAccessLayer.SP_GetSBP_Reserved_Result, Models.SP_GetSBP_Reserved_Result> mapObj = new EntitiyMapperBlotterReserved<DataAccessLayer.SP_GetSBP_Reserved_Result, Models.SP_GetSBP_Reserved_Result>();

            List<DataAccessLayer.SP_GetSBP_Reserved_Result> blotterReservedList = DAL.GetAllBlotterReserved(UserID, BranchID, BR);
            List<Models.SP_GetSBP_Reserved_Result> blotterReserved = new List<Models.SP_GetSBP_Reserved_Result>();
            foreach (var item in blotterReservedList)
            {
                blotterReserved.Add(mapObj.Translate(item));
            }
            return Json<List<Models.SP_GetSBP_Reserved_Result>>(blotterReserved);
        }


        [HttpPut]
        public bool UpdateReserved(Models.SBP_BlotterReserved blotterReserved)
        {
            bool status = false;

            if (ModelState.IsValid)
            {
                EntitiyMapperBlotterReserved<Models.SBP_BlotterReserved, DataAccessLayer.SBP_BlotterReserved> mapObj = new EntitiyMapperBlotterReserved<Models.SBP_BlotterReserved, DataAccessLayer.SBP_BlotterReserved>();
                DataAccessLayer.SBP_BlotterReserved ReservedObj = new DataAccessLayer.SBP_BlotterReserved();
                ReservedObj = mapObj.Translate(blotterReserved);
                status = DAL.UpdateReserved(ReservedObj);
            }
            return status;
        }
    }
}
