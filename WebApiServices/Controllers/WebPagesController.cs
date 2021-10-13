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
            EntityMapperWebPages<DataAccessLayer.WebPages, Models.WebPages> mapObj = new EntityMapperWebPages<DataAccessLayer.WebPages, Models.WebPages>();
            DataAccessLayer.WebPages dalBlotterTBO = DAL.GetWebPage(id);
            Models.WebPages products = new Models.WebPages();
            products = mapObj.Translate(dalBlotterTBO);

            return Json<Models.WebPages>(products);
        }
        [HttpGet]
        public JsonResult<List<Models.WebPages>> GetAllWebPage()
        {
            EntityMapperWebPages<DataAccessLayer.WebPages, Models.WebPages> mapObj = new EntityMapperWebPages<DataAccessLayer.WebPages, Models.WebPages>();

            List<DataAccessLayer.WebPages> WebPageList = DAL.GetAllWebPages();
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
                EntityMapperWebPages<Models.WebPages, DataAccessLayer.WebPages> mapObj = new EntityMapperWebPages<Models.WebPages, DataAccessLayer.WebPages>();
                DataAccessLayer.WebPages WebPageObj = new DataAccessLayer.WebPages();
                WebPageObj = mapObj.Translate(item);
                status = DAL.InsertWebPages(WebPageObj);
            }
            return status;

        }


        [HttpPut]
        public bool UpdateWebPage(Models.WebPages item)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                EntityMapperWebPages<Models.WebPages, DataAccessLayer.WebPages> mapObj = new EntityMapperWebPages<Models.WebPages, DataAccessLayer.WebPages>();
                DataAccessLayer.WebPages WebPageObj = new DataAccessLayer.WebPages();
                WebPageObj = mapObj.Translate(item);
                status = DAL.UpdateWebPages(WebPageObj);
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
