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
    public class BlotterDMMOController : ApiController
    {
        // GET: blotterDMMO
        [HttpGet]
        public JsonResult<Models.SBP_BlotterDMMO> GetblotterDMMO(int id)
        {


            EntitiyMapperBlotterDMMO<DataAccessLayer.SBP_BlotterDMMO, Models.SBP_BlotterDMMO> mapObj = new EntitiyMapperBlotterDMMO<DataAccessLayer.SBP_BlotterDMMO, Models.SBP_BlotterDMMO>();
            DataAccessLayer.SBP_BlotterDMMO dalblotterDMMO = DAL.GetDMMOItem(id);
            Models.SBP_BlotterDMMO products = new Models.SBP_BlotterDMMO();
            products = mapObj.Translate(dalblotterDMMO);
            return Json<Models.SBP_BlotterDMMO>(products);

        }

        [HttpGet]
        public JsonResult<List<Models.SP_GetSBP_DMMO_Result>> GetAllblotterDMMO(int UserID, int BranchID, int CurID, int BR, string DateVal)
        {

            EntitiyMapperBlotterDMMO<DataAccessLayer.SP_GetSBP_DMMO_Result, Models.SP_GetSBP_DMMO_Result> mapObj = new EntitiyMapperBlotterDMMO<DataAccessLayer.SP_GetSBP_DMMO_Result, Models.SP_GetSBP_DMMO_Result>();

            List<DataAccessLayer.SP_GetSBP_DMMO_Result> blotterDMMOList = DAL.GetAllBlotterDMMO(UserID, BranchID, BR, DateVal);
            List<Models.SP_GetSBP_DMMO_Result> blotterDMMO = new List<Models.SP_GetSBP_DMMO_Result>();
            foreach (var item in blotterDMMOList)
            {
                blotterDMMO.Add(mapObj.Translate(item));
            }
            return Json<List<Models.SP_GetSBP_DMMO_Result>>(blotterDMMO);
        }

        [HttpPost]
        public bool InsertDMMO(Models.SBP_BlotterDMMO blotterDMMO)
        {
            bool status = false;
            if (ModelState.IsValid)
            {

                EntitiyMapperBlotterDMMO<Models.SBP_BlotterDMMO, DataAccessLayer.SBP_BlotterDMMO> mapObj = new EntitiyMapperBlotterDMMO<Models.SBP_BlotterDMMO, DataAccessLayer.SBP_BlotterDMMO>();
                DataAccessLayer.SBP_BlotterDMMO DMMOObj = new DataAccessLayer.SBP_BlotterDMMO();
                DMMOObj = mapObj.Translate(blotterDMMO);
                status = DAL.InsertDMMO(DMMOObj);

            }
            return status;

        }

        [HttpPut]
        public bool UpdateDMMO(Models.SBP_BlotterDMMO blotterDMMO)
        {
            bool status = false;

            if (ModelState.IsValid)
            {
                EntitiyMapperBlotterDMMO<Models.SBP_BlotterDMMO, DataAccessLayer.SBP_BlotterDMMO> mapObj = new EntitiyMapperBlotterDMMO<Models.SBP_BlotterDMMO, DataAccessLayer.SBP_BlotterDMMO>();
                DataAccessLayer.SBP_BlotterDMMO DMMOObj = new DataAccessLayer.SBP_BlotterDMMO();
                DMMOObj = mapObj.Translate(blotterDMMO);
                status = DAL.UpdateDMMO(DMMOObj);
            }
            return status;
        }

        [HttpDelete]
        public bool DeleteDMMO(int id)
        {
            var status = DAL.DeleteDMMO(id);
            return status;
        }
    }
}
