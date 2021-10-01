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
    public class BlotterFundsTransferController : ApiController
    {

        // GET: BlotterFundsTransfer

        [HttpGet]
        public JsonResult<Models.SBP_BlotterFundsTransfer> GetBlotterFundsTransfer(int id)
        {
            EntityMapperBlotterFundsTransfer<DataAccessLayer.SBP_BlotterFundsTransfer, Models.SBP_BlotterFundsTransfer>
                mapObj = new EntityMapperBlotterFundsTransfer<DataAccessLayer.SBP_BlotterFundsTransfer, Models.SBP_BlotterFundsTransfer>();
            DataAccessLayer.SBP_BlotterFundsTransfer dalBlotterFundsTransfer = DAL.GetFundsTransferItem(id);
            Models.SBP_BlotterFundsTransfer products = new Models.SBP_BlotterFundsTransfer();
            products = mapObj.Translate(dalBlotterFundsTransfer);
            return Json<Models.SBP_BlotterFundsTransfer>(products);
        }

        [HttpGet]
        public JsonResult<List<Models.SBP_BlotterFundsTransfer>> GetAllBlotterFundsTransfer(int UserID, int BranchID, int CurID, int BR, string DateVal)
        {
            EntityMapperBlotterFundsTransfer<DataAccessLayer.SBP_BlotterFundsTransfer, Models.SBP_BlotterFundsTransfer> mapObj = new EntityMapperBlotterFundsTransfer<DataAccessLayer.SBP_BlotterFundsTransfer, Models.SBP_BlotterFundsTransfer>();

            List<DataAccessLayer.SBP_BlotterFundsTransfer> blotterFundsTransferList = DAL.GetAllBlotterFundsTransfer(UserID, BranchID, CurID, BR,DateVal);
            List<Models.SBP_BlotterFundsTransfer> blotterFundsTransfer = new List<Models.SBP_BlotterFundsTransfer>();
            foreach (var item in blotterFundsTransferList)
            {
                blotterFundsTransfer.Add(mapObj.Translate(item));
            }
            return Json<List<Models.SBP_BlotterFundsTransfer>>(blotterFundsTransfer);
        }
        [HttpPost]
        public bool InsertFundsTransfer(Models.SBP_BlotterFundsTransfer blotterFundsTransfer)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                EntityMapperBlotterFundsTransfer<Models.SBP_BlotterFundsTransfer, DataAccessLayer.SBP_BlotterFundsTransfer> mapObj = new EntityMapperBlotterFundsTransfer<Models.SBP_BlotterFundsTransfer, DataAccessLayer.SBP_BlotterFundsTransfer>();
                DataAccessLayer.SBP_BlotterFundsTransfer FundsTransferObj = new DataAccessLayer.SBP_BlotterFundsTransfer();
                FundsTransferObj = mapObj.Translate(blotterFundsTransfer);
                status = DAL.InsertFundsTransfer(FundsTransferObj);
            }
            return status;

        }


        [HttpPut]
        public bool UpdateFundsTransfer(Models.SBP_BlotterFundsTransfer blotterFundsTransfer)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                EntityMapperBlotterFundsTransfer<Models.SBP_BlotterFundsTransfer, DataAccessLayer.SBP_BlotterFundsTransfer> mapObj = new EntityMapperBlotterFundsTransfer<Models.SBP_BlotterFundsTransfer, DataAccessLayer.SBP_BlotterFundsTransfer>();
                DataAccessLayer.SBP_BlotterFundsTransfer FundsTransferObj = new DataAccessLayer.SBP_BlotterFundsTransfer();
                FundsTransferObj = mapObj.Translate(blotterFundsTransfer);
                status = DAL.UpdateFundsTransfer(FundsTransferObj);
            }
            return status;

        }

        [HttpDelete]
        public bool DeleteFundsTransfer(int id)
        {
            var status = DAL.DeleteFundsTransfer(id);
            return status;
        }
    }
}
