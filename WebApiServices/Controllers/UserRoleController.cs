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
    public class UserRoleController : ApiController
    {
        // GET: UserRole

        [HttpGet]
        public JsonResult<Models.UserRole> GetUserRole(int id)
        {
            EntityMapperUserRole<DataAccessLayer.SP_GETUserRoles_Result, Models.UserRole> mapObj = new EntityMapperUserRole<DataAccessLayer.SP_GETUserRoles_Result, Models.UserRole>();
            DataAccessLayer.SP_GETUserRoles_Result dalBlotterTBO = DAL.GetUserRole(id);
            Models.UserRole products = new Models.UserRole();
            products = mapObj.Translate(dalBlotterTBO);
            return Json<Models.UserRole>(products);
        }
        [HttpGet]
        public JsonResult<List<Models.UserRole>> GetAllUserRole()
        {
            EntityMapperUserRole<DataAccessLayer.SP_GETUserRoles_Result, Models.UserRole> mapObj = new EntityMapperUserRole<DataAccessLayer.SP_GETUserRoles_Result, Models.UserRole>();

            List<DataAccessLayer.SP_GETUserRoles_Result> UserRoleList = DAL.GetAllUserRole();
            List<Models.UserRole> blotterUserRole = new List<Models.UserRole>();
            foreach (var item in UserRoleList)
            {
                blotterUserRole.Add(mapObj.Translate(item));
            }
            return Json<List<Models.UserRole>>(blotterUserRole);
        }
        [HttpPost]
        public bool InsertUserRole(Models.UserRole item)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                status = DAL.InsertUserRole(item.RoleName,item.isActive);
            }
            return status;

        }


        [HttpPut]
        public bool UpdateUserRole(Models.UserRole item)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                status = DAL.UpdateUserRole(item.URID,item.RoleName, item.isActive);
            }
            return status;

        }

        [HttpDelete]
        public bool DeleteUserRole(int id)
        {
            var status = DAL.DeleteUserRole(id);
            return status;
        }
    }
}
