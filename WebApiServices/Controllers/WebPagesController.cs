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
    public class WebPagesController : ApiController
    {

        [HttpGet]
        public JsonResult<Models.WebPages> GetWebPage(int id)
        {
            EntityMapperWebPages<DataAccessLayer.SP_GetAllWebPages_Result, Models.WebPages> mapObj = new EntityMapperWebPages<DataAccessLayer.SP_GetAllWebPages_Result, Models.WebPages>();
            DataAccessLayer.SP_GetAllWebPages_Result dalBlotterTBO = DAL.GetWebPage(id);
            Models.WebPages products = new Models.WebPages();
            products = mapObj.Translate(dalBlotterTBO);

            return Json<Models.WebPages>(products);
        }
        [HttpGet]
        public JsonResult<List<Models.WebPages>> GetAllWebPage()
        {
            EntityMapperWebPages<DataAccessLayer.SP_GetAllWebPages_Result, Models.WebPages> mapObj = new EntityMapperWebPages<DataAccessLayer.SP_GetAllWebPages_Result, Models.WebPages>();

            List<DataAccessLayer.SP_GetAllWebPages_Result> WebPageList = DAL.GetAllWebPages();
            List<Models.WebPages> blotterWebPage = new List<Models.WebPages>();
            foreach (var item in WebPageList)
            {
                blotterWebPage.Add(mapObj.Translate(item));
            }
            return Json<List<Models.WebPages>>(blotterWebPage);
        }
        [HttpPost]
        public bool InsertWebPage(Models.WebPages item)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                status = DAL.InsertWebPages(item.PageName,item.ControllerName,item.DisplayName,item.PageDescription,item.BlotterType,item.isActive);
            }
            return status;

        }


        [HttpPut]
        public bool UpdateWebPage(Models.WebPages item)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                status = DAL.UpdateWebPages(item.WPID,item.PageName, item.ControllerName, item.DisplayName, item.PageDescription, item.BlotterType, item.isActive);
            }
            return status;

        }

        [HttpDelete]
        public bool DeleteWebPage(int id)
        {
            var status = DAL.DeleteWebPages(id);
            return status;
        }
    }
}
