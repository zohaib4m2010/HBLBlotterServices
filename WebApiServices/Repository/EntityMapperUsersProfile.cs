using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiServices.Repository
{
    public class EntityMapperUsersProfile<TSource, TDestination> where TSource : class where TDestination : class
    {
        public EntityMapperUsersProfile()
        {

            Mapper.CreateMap<Models.SBP_LoginInfo, DataAccessLayer.SBP_LoginInfo>();
            Mapper.CreateMap<DataAccessLayer.SBP_LoginInfo, Models.SBP_LoginInfo>();

            Mapper.CreateMap<Models.sp_GetAllUsers_Result, DataAccessLayer.sp_GetAllUsers_Result>();
            Mapper.CreateMap<DataAccessLayer.sp_GetAllUsers_Result, Models.sp_GetAllUsers_Result>();

            Mapper.CreateMap<Models.UserRole, DataAccessLayer.SP_GETUserRoles_Result>();
            Mapper.CreateMap<DataAccessLayer.SP_GETUserRoles_Result, Models.UserRole>();


            Mapper.CreateMap<Models.SBP_LoginInfoWithRoleId, DataAccessLayer.sp_GetUserById_Result>();
            Mapper.CreateMap<DataAccessLayer.sp_GetUserById_Result, Models.SBP_LoginInfoWithRoleId>();
        }
        public TDestination Translate(TSource obj)
        {
            return Mapper.Map<TDestination>(obj);
        }
    }
}