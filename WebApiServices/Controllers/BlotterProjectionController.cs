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
    public class BlotterProjectionController : ApiController
    {

        [HttpGet]
        public JsonResult<Models.SBP_BlotterProjection> GetblotterProjection(int id)
        {


            EntityMapperBlotterProjection<DataAccessLayer.SBP_BlotterProjection, Models.SBP_BlotterProjection> mapObj = new EntityMapperBlotterProjection<DataAccessLayer.SBP_BlotterProjection, Models.SBP_BlotterProjection>();
            DataAccessLayer.SBP_BlotterProjection dalblotterProjection = DAL.GetProjectionItem(id);
            Models.SBP_BlotterProjection products = new Models.SBP_BlotterProjection();
            products = mapObj.Translate(dalblotterProjection);
            return Json<Models.SBP_BlotterProjection>(products);

        }

        [HttpGet]
        public JsonResult<List<Models.SP_Get_BlotterProjection_Result>> GetAllblotterProjection(int UserID, int BranchID, int CurID, int BR, string DateVal)
        {

            EntityMapperBlotterProjection<DataAccessLayer.SP_GetSBP_Projection_Result, Models.SP_Get_BlotterProjection_Result> mapObj = new EntityMapperBlotterProjection<DataAccessLayer.SP_GetSBP_Projection_Result, Models.SP_Get_BlotterProjection_Result>();

            List<DataAccessLayer.SP_GetSBP_Projection_Result> blotterProjList = DAL.GetAllBlotterProjection(UserID, BranchID, BR, DateVal);
            List<Models.SP_Get_BlotterProjection_Result> blotterProj = new List<Models.SP_Get_BlotterProjection_Result>();
            foreach (var item in blotterProjList)
            {
                blotterProj.Add(mapObj.Translate(item));
            }
            return Json<List<Models.SP_Get_BlotterProjection_Result>>(blotterProj);
        }

        [HttpPost]
        public bool InsertProjection(Models.SBP_BlotterProjection blotterProjection)
        {
            bool status = false;
            if (ModelState.IsValid)
            {

                EntityMapperBlotterProjection<Models.SBP_BlotterProjection, DataAccessLayer.SBP_BlotterProjection> mapObj = new EntityMapperBlotterProjection<Models.SBP_BlotterProjection, DataAccessLayer.SBP_BlotterProjection>();
                DataAccessLayer.SBP_BlotterProjection ProObj = new DataAccessLayer.SBP_BlotterProjection();
                ProObj = mapObj.Translate(blotterProjection);
                status = DAL.InsertProjection(ProObj);
            }
            return status;

        }

        [HttpPut]
        public bool UpdateProjection(Models.SBP_BlotterProjection blotterProjection)
        {
            bool status = false;

            if (ModelState.IsValid)
            {
                EntityMapperBlotterProjection<Models.SBP_BlotterProjection, DataAccessLayer.SBP_BlotterProjection> mapObj = new EntityMapperBlotterProjection<Models.SBP_BlotterProjection, DataAccessLayer.SBP_BlotterProjection>();
                DataAccessLayer.SBP_BlotterProjection ProjObj = new DataAccessLayer.SBP_BlotterProjection();
                ProjObj = mapObj.Translate(blotterProjection);
                status = DAL.UpdateProjection(ProjObj);
            }
            return status;
        }

        [HttpDelete]
        public bool DeleteProjection(int id)
        {
            var status = DAL.DeleteProjection(id);
            return status;
        }
    }
}
