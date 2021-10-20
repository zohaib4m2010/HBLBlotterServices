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
    public class UsersProfileController : ApiController
    {
        // GET: BlotterUsers

        [HttpGet]
        public JsonResult<Models.SBP_LoginInfoWithRoleId> GetUser(int id)
        {
            EntityMapperUsersProfile<DataAccessLayer.sp_GetUserById_Result, Models.SBP_LoginInfoWithRoleId> mapObj = new EntityMapperUsersProfile<DataAccessLayer.sp_GetUserById_Result, Models.SBP_LoginInfoWithRoleId>();
            DataAccessLayer.sp_GetUserById_Result dalBranches = DAL.GetUser(id);
            Models.SBP_LoginInfoWithRoleId products = new Models.SBP_LoginInfoWithRoleId();
            products = mapObj.Translate(dalBranches);
            return Json<Models.SBP_LoginInfoWithRoleId>(products);
        }
        [HttpGet]
        public JsonResult<List<Models.sp_GetAllUsers_Result>> GetAllUsers()
        {
            EntityMapperUsersProfile<DataAccessLayer.sp_GetAllUsers_Result, Models.sp_GetAllUsers_Result> mapObj = new EntityMapperUsersProfile<DataAccessLayer.sp_GetAllUsers_Result, Models.sp_GetAllUsers_Result>();

            List<DataAccessLayer.sp_GetAllUsers_Result> BranchesList = DAL.GetAllUsers();
            List<Models.sp_GetAllUsers_Result> blotterUsers = new List<Models.sp_GetAllUsers_Result>();
            foreach (var item in BranchesList)
            {
                blotterUsers.Add(mapObj.Translate(item));
            }
            return Json<List<Models.sp_GetAllUsers_Result>>(blotterUsers);
        }
        [HttpPost]
        public bool InsertUser(Models.SBP_LoginInfoWithRoleId item)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                EntityMapperUsersProfile<Models.SBP_LoginInfoWithRoleId, DataAccessLayer.sp_GetUserById_Result> mapObj = new EntityMapperUsersProfile<Models.SBP_LoginInfoWithRoleId, DataAccessLayer.sp_GetUserById_Result>();
                DataAccessLayer.sp_GetUserById_Result UsersObj = new DataAccessLayer.sp_GetUserById_Result();
                UsersObj = mapObj.Translate(item);
                status = DAL.InsertUser(UsersObj);
                //status = DAL.InsertUser(item.UserName,item.Password,item.ContactNo,item.Email,item.BranchId,item.isActive,item.CreateDate,item.URID);
            }
            return status;

        }


        [HttpPut]
        public bool UpdateUser(Models.SBP_LoginInfoWithRoleId item)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                EntityMapperUsersProfile<Models.SBP_LoginInfoWithRoleId, DataAccessLayer.sp_GetUserById_Result> mapObj = new EntityMapperUsersProfile<Models.SBP_LoginInfoWithRoleId, DataAccessLayer.sp_GetUserById_Result>();
                DataAccessLayer.sp_GetUserById_Result UsersObj = new DataAccessLayer.sp_GetUserById_Result();
                UsersObj = mapObj.Translate(item);
                status = DAL.UpdateUser(UsersObj);
            }
            return status;

        }

        [HttpDelete]
        public bool DeleteUser(int id)
        {
            var status = DAL.DeleteUser(id);
            return status;
        }


        [HttpGet]
        public JsonResult<List<Models.UserRole>> GetUserRoles()
        {
            EntityMapperUsersProfile<DataAccessLayer.SP_GETUserRoles_Result, Models.UserRole> mapObj = new EntityMapperUsersProfile<DataAccessLayer.SP_GETUserRoles_Result, Models.UserRole>();

            List<DataAccessLayer.SP_GETUserRoles_Result> BranchesList = DAL.GetUserRoles();
            List<Models.UserRole> blotterBranches = new List<Models.UserRole>();
            foreach (var item in BranchesList)
            {
                blotterBranches.Add(mapObj.Translate(item));
            }
            return Json<List<Models.UserRole>>(blotterBranches);
        }


    }
}