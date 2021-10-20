using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiServices.Repository
{
    public class EntityMapperWebPages<TSource, TDestination> where TSource : class where TDestination : class
    {
        public EntityMapperWebPages()
        {

            Mapper.CreateMap<Models.WebPages, DataAccessLayer.SP_GetAllWebPages_Result>();
            Mapper.CreateMap<DataAccessLayer.SP_GetAllWebPages_Result, Models.WebPages>();
            Mapper.CreateMap<Models.WebPages, DataAccessLayer.SP_GetNotListedUserPageRelations_Result>();
            Mapper.CreateMap<DataAccessLayer.SP_GetNotListedUserPageRelations_Result, Models.WebPages>();
        }
        public TDestination Translate(TSource obj)
        {
            return Mapper.Map<TDestination>(obj);
        }
    }
}