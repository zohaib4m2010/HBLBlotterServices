using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;

using WebApiServices.Repository;

namespace WebApiServices.Controllers
{
    public class BlotterOutRightController : ApiController
    {
        // GET: BlotterOutRight



        [HttpGet]
        public JsonResult<List<Models.SP_GetSBPBlotterOR_Result>> GetAllblotterOutRight(int UserID, int BranchID, int CurID, int BR, string DateVal)
        {
            EntityMapperBlotterOR<DataAccessLayer.SP_GetSBPBlotterOutRright_Result, Models.SP_GetSBPBlotterOR_Result> mapObj = new EntityMapperBlotterOR<DataAccessLayer.SP_GetSBPBlotterOutRright_Result, Models.SP_GetSBPBlotterOR_Result>();

            List<DataAccessLayer.SP_GetSBPBlotterOutRright_Result> blotterORList = DAL.GetAllBlotterOutRight(UserID, BranchID, CurID, BR, DateVal);
            List<Models.SP_GetSBPBlotterOR_Result> blotterOR = new List<Models.SP_GetSBPBlotterOR_Result>();
            foreach (var item in blotterORList)
            {
                blotterOR.Add(mapObj.Translate(item));
            }
            return Json<List<Models.SP_GetSBPBlotterOR_Result>>(blotterOR);
        }

        [HttpGet]
        public JsonResult<List<Models.SP_GetSBPBlotterOR_Result>> GetAllBlotterOutRightAuto(int UserID, int BranchID, int CurID, int BR, string DateVal)
        {
            EntityMapperBlotterOR<DataAccessLayer.SP_GetSBPBlotterOutRrightAuto_Result, Models.SP_GetSBPBlotterOR_Result> mapObj = new EntityMapperBlotterOR<DataAccessLayer.SP_GetSBPBlotterOutRrightAuto_Result, Models.SP_GetSBPBlotterOR_Result>();

            List<DataAccessLayer.SP_GetSBPBlotterOutRrightAuto_Result> blotterORList = DAL.GetAllBlotterOutRightAuto(UserID, BranchID, CurID, BR, DateVal);
            List<Models.SP_GetSBPBlotterOR_Result> blotterOR = new List<Models.SP_GetSBPBlotterOR_Result>();
            foreach (var item in blotterORList)
            {
                blotterOR.Add(mapObj.Translate(item));
            }
            return Json<List<Models.SP_GetSBPBlotterOR_Result>>(blotterOR);
        }

        [HttpPost]
        public bool InsertOutRight(List<Models.SBP_BlotterOutRight> blotterOR)
        {
            bool status = false;

            if (ModelState.IsValid)
            {

                EntityMapperBlotterOR<Models.SBP_BlotterOutRight, DataAccessLayer.SBP_BlotterOutrights> mapObj = new EntityMapperBlotterOR<Models.SBP_BlotterOutRight, DataAccessLayer.SBP_BlotterOutrights>();
                DataAccessLayer.SBP_BlotterOutrights FRObj = new DataAccessLayer.SBP_BlotterOutrights();
                for (int i = 0; i < blotterOR.Count; i++)
                {
                    //blotterFR[i].DataType=()
                    FRObj = mapObj.Translate(blotterOR[i]);
                    status = DAL.InsertOutRight(FRObj);
                }
            }
            return status;
        }

        [HttpPost]
        public bool AddOutRight(Models.SBP_BlotterOutRight blotterOR)
        {
            bool status = false;
            EntityMapperBlotterOR<Models.SBP_BlotterOutRight, DataAccessLayer.SBP_BlotterOutrights> mapObj = new EntityMapperBlotterOR<Models.SBP_BlotterOutRight, DataAccessLayer.SBP_BlotterOutrights>();
            DataAccessLayer.SBP_BlotterOutrights FRObj = new DataAccessLayer.SBP_BlotterOutrights();
            FRObj = mapObj.Translate(blotterOR);
            status = DAL.InsertOutRight(FRObj);
            return status;
        }

        [HttpPut]
        public bool UpdateOutRight(Models.SBP_BlotterOutRight OutRight)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                EntityMapperBlotterOR<Models.SBP_BlotterOutRight, DataAccessLayer.SBP_BlotterOutrights> mapObj = new EntityMapperBlotterOR<Models.SBP_BlotterOutRight, DataAccessLayer.SBP_BlotterOutrights>();
                DataAccessLayer.SBP_BlotterOutrights OROBj = new DataAccessLayer.SBP_BlotterOutrights();
                OROBj = mapObj.Translate(OutRight);
                status = DAL.UpdateOutRight(OROBj);
            }
            return status;


        }
        [HttpPost]
        public bool DeleteOutRight(IEnumerable<int> Ids)
        {
            bool status = false;
            foreach (var item in Ids)
            {
                status = DAL.DeleteOutRight(item,0);
            }
            return status;
        }
    }
}