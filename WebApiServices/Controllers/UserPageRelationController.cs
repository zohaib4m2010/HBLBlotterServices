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
    public class UserPageRelationController : ApiController
    {

        [HttpGet]
        public JsonResult<List<Models.UserRole>> GetAllActiveUserRole()
        {
            EntityMapperUserRole<DataAccessLayer.SP_GETUserRoles_Result, Models.UserRole> mapObj = new EntityMapperUserRole<DataAccessLayer.SP_GETUserRoles_Result, Models.UserRole>();

            List<DataAccessLayer.SP_GETUserRoles_Result> UserRoleList = DAL.GetActiveUserRoles();
            List<Models.UserRole> blotterUserRole = new List<Models.UserRole>();
            foreach (var item in UserRoleList)
            {
                blotterUserRole.Add(mapObj.Translate(item));
            }
            return Json<List<Models.UserRole>>(blotterUserRole);
        }

        [HttpGet]
        public JsonResult<List<Models.WebPages>> GetActiveWebPages(int URID)
        {
            EntityMapperWebPages<DataAccessLayer.SP_GetNotListedUserPageRelations_Result, Models.WebPages> mapObj = new EntityMapperWebPages<DataAccessLayer.SP_GetNotListedUserPageRelations_Result, Models.WebPages>();

            List<DataAccessLayer.SP_GetNotListedUserPageRelations_Result> WebPageList = DAL.GetActiveWebPages(URID);
            List<Models.WebPages> blotterWebPage = new List<Models.WebPages>();
            foreach (var item in WebPageList)
            {
                blotterWebPage.Add(mapObj.Translate(item));
            }
            return Json<List<Models.WebPages>>(blotterWebPage);
        }

        [HttpGet]
        public JsonResult<List<Models.SP_GetAllUserPageRelations_Result>> GetUserPageRaltions(int URID)
        {
            EntityMapperUserPageRelation<DataAccessLayer.SP_GetAllUserPageRelations_Result, Models.SP_GetAllUserPageRelations_Result> mapObj = new EntityMapperUserPageRelation<DataAccessLayer.SP_GetAllUserPageRelations_Result, Models.SP_GetAllUserPageRelations_Result>();

            List<DataAccessLayer.SP_GetAllUserPageRelations_Result> UserPageRelationsList = DAL.GetAllUserPageRelations(URID);
            List<Models.SP_GetAllUserPageRelations_Result> UserPageRelations = new List<Models.SP_GetAllUserPageRelations_Result>();
            foreach (var item in UserPageRelationsList)
            {
                UserPageRelations.Add(mapObj.Translate(item));
            }
            return Json<List<Models.SP_GetAllUserPageRelations_Result>>(UserPageRelations);
        }



        [HttpGet]
        public JsonResult<Models.SP_GetAllUserPageRelations_Result> GetUserPageRaltion(int UPRID)
        {
            EntityMapperUserPageRelation<DataAccessLayer.SP_GetUserPageRelationById_Result, Models.SP_GetAllUserPageRelations_Result> mapObj = new EntityMapperUserPageRelation<DataAccessLayer.SP_GetUserPageRelationById_Result, Models.SP_GetAllUserPageRelations_Result>();

            DataAccessLayer.SP_GetUserPageRelationById_Result UserPageRelationsList = DAL.GetUserPageRelationById(UPRID);
            Models.SP_GetAllUserPageRelations_Result UserPageRelation = new Models.SP_GetAllUserPageRelations_Result();
            UserPageRelation=mapObj.Translate(UserPageRelationsList);
            
            return Json<Models.SP_GetAllUserPageRelations_Result>(UserPageRelation);
        }

        [HttpGet]
        public JsonResult<Models.WebPages> GetWebPageById(int WPID)
        {
            EntityMapperWebPages<DataAccessLayer.SP_GetAllWebPages_Result, Models.WebPages> mapObj = new EntityMapperWebPages<DataAccessLayer.SP_GetAllWebPages_Result, Models.WebPages>();

            DataAccessLayer.SP_GetAllWebPages_Result WebPageList = DAL.GetWebPageById(WPID);
            Models.WebPages Webpage = new Models.WebPages();
            Webpage = mapObj.Translate(WebPageList);

            return Json<Models.WebPages>(Webpage);
        }

        [HttpPost]
        public bool InsertUserPageRelation(Models.UserPageRelation item)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                status = DAL.InsertUserPageRelation(item.URID,item.WPID,item.DateChangeAccess,item.EditAccess,item.DeleteAccess);
            }
            return status;

        }



        [HttpPut]
        public bool UpdateUserPageRelation(Models.UserPageRelation item)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                status = DAL.UpdateUserPageRelation(item.UPRID,item.URID, item.WPID, item.DateChangeAccess, item.EditAccess, item.DeleteAccess);
            }
            return status;

        }



        [HttpDelete]
        public bool DeleteUserPageRelation(int UPRID)
        { 
            var status = DAL.DeleteUserPageRelation(UPRID);
            return status;
        }

}
}
