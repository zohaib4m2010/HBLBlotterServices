using AutoMapper;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiServices.Models;

namespace WebApiServices.Repository
{
    public class EntityMapperUserPageRelation<TSource, TDestination> where TSource : class where TDestination : class
    {
        public EntityMapperUserPageRelation()
        {

            Mapper.CreateMap<Models.UserPageRelation, DataAccessLayer.SP_GetAllUserPageRelations_Result>();
            Mapper.CreateMap<DataAccessLayer.SP_GetAllUserPageRelations_Result, Models.UserPageRelation>();

            

            Mapper.CreateMap<Models.SP_GetAllUserPageRelations_Result, DataAccessLayer.SP_GetAllUserPageRelations_Result>();
            Mapper.CreateMap<DataAccessLayer.SP_GetAllUserPageRelations_Result, Models.SP_GetAllUserPageRelations_Result>();

            Mapper.CreateMap<Models.SP_GetAllUserPageRelations_Result, DataAccessLayer.SP_GetUserPageRelationById_Result>();
            Mapper.CreateMap<DataAccessLayer.SP_GetUserPageRelationById_Result, Models.SP_GetAllUserPageRelations_Result>();
        }
        public TDestination Translate(TSource obj)
        {
            return Mapper.Map<TDestination>(obj);
        }
        
    }
}