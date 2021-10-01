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
    public class BlotterBai_MuajjalController : ApiController
    {

        // GET: BlotterBai_Muajjal

        [HttpGet]
        public JsonResult<Models.SBP_BlotterBai_Muajjal> GetBlotterBai_Muajjal(int id)
        {
            EntityMapperBlotterBai_Muajjal<DataAccessLayer.SBP_BlotterBai_Muajjal, Models.SBP_BlotterBai_Muajjal>
                mapObj = new EntityMapperBlotterBai_Muajjal<DataAccessLayer.SBP_BlotterBai_Muajjal, Models.SBP_BlotterBai_Muajjal>();
            DataAccessLayer.SBP_BlotterBai_Muajjal dalBlotterBai_Muajjal = DAL.GetBai_MuajjalItem(id);
            Models.SBP_BlotterBai_Muajjal products = new Models.SBP_BlotterBai_Muajjal();
            products = mapObj.Translate(dalBlotterBai_Muajjal);
            return Json<Models.SBP_BlotterBai_Muajjal>(products);
        }

        [HttpGet]
        public JsonResult<List<Models.SBP_BlotterBai_Muajjal>> GetAllBlotterBai_Muajjal(int UserID, int BranchID, int CurID, int BR, string DateVal)
        {
            EntityMapperBlotterBai_Muajjal<DataAccessLayer.SBP_BlotterBai_Muajjal, Models.SBP_BlotterBai_Muajjal> mapObj = new EntityMapperBlotterBai_Muajjal<DataAccessLayer.SBP_BlotterBai_Muajjal, Models.SBP_BlotterBai_Muajjal>();

            List<DataAccessLayer.SBP_BlotterBai_Muajjal> blotterBai_MuajjalList = DAL.GetAllBlotterBai_Muajjal(UserID, BranchID, CurID, BR,DateVal);
            List<Models.SBP_BlotterBai_Muajjal> blotterBai_Muajjal = new List<Models.SBP_BlotterBai_Muajjal>();
            foreach (var item in blotterBai_MuajjalList)
            {
                blotterBai_Muajjal.Add(mapObj.Translate(item));
            }
            return Json<List<Models.SBP_BlotterBai_Muajjal>>(blotterBai_Muajjal);
        }
        [HttpPost]
        public bool InsertBai_Muajjal(Models.SBP_BlotterBai_Muajjal blotterBai_Muajjal)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                EntityMapperBlotterBai_Muajjal<Models.SBP_BlotterBai_Muajjal, DataAccessLayer.SBP_BlotterBai_Muajjal> mapObj = new EntityMapperBlotterBai_Muajjal<Models.SBP_BlotterBai_Muajjal, DataAccessLayer.SBP_BlotterBai_Muajjal>();
                DataAccessLayer.SBP_BlotterBai_Muajjal Bai_MuajjalObj = new DataAccessLayer.SBP_BlotterBai_Muajjal();
                Bai_MuajjalObj = mapObj.Translate(blotterBai_Muajjal);
                status = DAL.InsertBai_Muajjal(Bai_MuajjalObj);
            }
            return status;

        }


        [HttpPut]
        public bool UpdateBai_Muajjal(Models.SBP_BlotterBai_Muajjal blotterBai_Muajjal)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                EntityMapperBlotterBai_Muajjal<Models.SBP_BlotterBai_Muajjal, DataAccessLayer.SBP_BlotterBai_Muajjal> mapObj = new EntityMapperBlotterBai_Muajjal<Models.SBP_BlotterBai_Muajjal, DataAccessLayer.SBP_BlotterBai_Muajjal>();
                DataAccessLayer.SBP_BlotterBai_Muajjal Bai_MuajjalObj = new DataAccessLayer.SBP_BlotterBai_Muajjal();
                Bai_MuajjalObj = mapObj.Translate(blotterBai_Muajjal);
                status = DAL.UpdateBai_Muajjal(Bai_MuajjalObj);
            }
            return status;

        }

        [HttpDelete]
        public bool DeleteBai_Muajjal(int id)
        {
            var status = DAL.DeleteBai_Muajjal(id);
            return status;
        }
    }
}
