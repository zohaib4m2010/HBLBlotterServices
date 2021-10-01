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
    public class BlotterCRDController : ApiController
    {

        // GET: blotterCRD
        [HttpGet]
        public JsonResult<Models.SBP_BlotterCRD> GetblotterCRD(int id)
        {
            EntitiyMapperBlotterCRD<DataAccessLayer.SBP_BlotterCRD, Models.SBP_BlotterCRD> mapObj = new EntitiyMapperBlotterCRD<DataAccessLayer.SBP_BlotterCRD, Models.SBP_BlotterCRD>();
            DataAccessLayer.SBP_BlotterCRD dalblotterCRD = DAL.GetCRDItem(id);
            Models.SBP_BlotterCRD products = new Models.SBP_BlotterCRD();
            products = mapObj.Translate(dalblotterCRD);
            return Json<Models.SBP_BlotterCRD>(products);
        }
        [HttpGet]
        public JsonResult<List<Models.SP_GetSBPBlotterCRD_Result>> GetAllblotterCRD(int UserID, int BranchID, int CurID, int BR)
        {
            EntitiyMapperBlotterCRD<DataAccessLayer.SP_GetSBPBlotterCRD_Result, Models.SP_GetSBPBlotterCRD_Result> mapObj = new EntitiyMapperBlotterCRD<DataAccessLayer.SP_GetSBPBlotterCRD_Result, Models.SP_GetSBPBlotterCRD_Result>();

            List<DataAccessLayer.SP_GetSBPBlotterCRD_Result> blotterCRDList = DAL.GetAllBlotterCRD(UserID, BranchID, CurID, BR);
            List<Models.SP_GetSBPBlotterCRD_Result> blotterCRD = new List<Models.SP_GetSBPBlotterCRD_Result>();
            foreach (var item in blotterCRDList)
            {
                blotterCRD.Add(mapObj.Translate(item));
            }
            return Json<List<Models.SP_GetSBPBlotterCRD_Result>>(blotterCRD);
        }
        [HttpPost]
        public bool InsertCRD(Models.SBP_BlotterCRD blotterCRD)
        {
            bool status = false;
            if (ModelState.IsValid)
            {

                EntitiyMapperBlotterCRD<Models.SBP_BlotterCRD, DataAccessLayer.SBP_BlotterCRD> mapObj = new EntitiyMapperBlotterCRD<Models.SBP_BlotterCRD, DataAccessLayer.SBP_BlotterCRD>();
                DataAccessLayer.SBP_BlotterCRD CRDObj = new DataAccessLayer.SBP_BlotterCRD();
                CRDObj = mapObj.Translate(blotterCRD);
                status = DAL.InsertCRD(CRDObj);
            }
            return status;
        }


        [HttpPut]
        public bool UpdateCRD(Models.SBP_BlotterCRD blotterCRD)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                EntitiyMapperBlotterCRD<Models.SBP_BlotterCRD, DataAccessLayer.SBP_BlotterCRD> mapObj = new EntitiyMapperBlotterCRD<Models.SBP_BlotterCRD, DataAccessLayer.SBP_BlotterCRD>();
                DataAccessLayer.SBP_BlotterCRD CRDObj = new DataAccessLayer.SBP_BlotterCRD();
                CRDObj = mapObj.Translate(blotterCRD);
                status = DAL.UpdateCRD(CRDObj);
            }
            return status;
        }

        [HttpDelete]
        public bool DeleteCRD(int id)
        {
            var status = DAL.DeleteCRD(id);
            return status;
        }
    }
}
