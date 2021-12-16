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
    public class BlotterShedulerController : ApiController
    {

        [HttpGet]
        public JsonResult<List<Models.SP_GetSBPBlotterGetSheduler_Result>> GetBlotterSheduler()
        {
            EntityMapperBlotterSheduler<DataAccessLayer.SP_GetSBPBlotterGetSheduler_Result, Models.SP_GetSBPBlotterGetSheduler_Result> mapObj = new EntityMapperBlotterSheduler<DataAccessLayer.SP_GetSBPBlotterGetSheduler_Result, Models.SP_GetSBPBlotterGetSheduler_Result>();

            List<DataAccessLayer.SP_GetSBPBlotterGetSheduler_Result> blotterShedulerList = DAL.GetAllBlotterShedular();
            List<Models.SP_GetSBPBlotterGetSheduler_Result> blotterSheduler = new List<Models.SP_GetSBPBlotterGetSheduler_Result>();
            foreach (var item in blotterShedulerList)
            {
                blotterSheduler.Add(mapObj.Translate(item));
            }
            return Json<List<Models.SP_GetSBPBlotterGetSheduler_Result>>(blotterSheduler);
        }


        [HttpGet]
        public JsonResult<Models.BlotterSBP_Sheduler> GetBlotterShedulerid(int id)
        {
            EntityMapperBlotterSheduler<DataAccessLayer.BlotterSBP_Sheduler, Models.BlotterSBP_Sheduler> mapObj = new EntityMapperBlotterSheduler<DataAccessLayer.BlotterSBP_Sheduler, Models.BlotterSBP_Sheduler>();
            DataAccessLayer.BlotterSBP_Sheduler dalBlotterSheduler = DAL.GetBlotterShedularID(id);
            Models.BlotterSBP_Sheduler products = new Models.BlotterSBP_Sheduler();
            products = mapObj.Translate(dalBlotterSheduler);
            return Json<Models.BlotterSBP_Sheduler>(products);
        }
        [HttpPut]
        public bool UpdateSheduler(Models.BlotterSBP_Sheduler blotterSheduler)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                EntityMapperBlotterSheduler<Models.BlotterSBP_Sheduler, DataAccessLayer.BlotterSBP_Sheduler> mapObj = new EntityMapperBlotterSheduler<Models.BlotterSBP_Sheduler, DataAccessLayer.BlotterSBP_Sheduler>();
                DataAccessLayer.BlotterSBP_Sheduler ShedulerObj = new DataAccessLayer.BlotterSBP_Sheduler();
                ShedulerObj = mapObj.Translate(blotterSheduler);
                status = DAL.UpdateSheduler(ShedulerObj);
            }
            return status;

        }

        [HttpDelete]
        public bool DeleteClearing(int id)
        {
            var status = DAL.DeleteClearing(id);
            return status;
        }
    }
}