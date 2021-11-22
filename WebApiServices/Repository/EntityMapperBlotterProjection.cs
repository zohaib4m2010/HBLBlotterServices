using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiServices.Repository
{
    public class EntityMapperBlotterProjection<TSource, TDestination> where TSource : class where TDestination : class
    {
        public EntityMapperBlotterProjection()
        {

            Mapper.CreateMap<Models.SP_Get_BlotterProjection_Result, DataAccessLayer.SP_GetSBP_Projection_Result>();
            Mapper.CreateMap<DataAccessLayer.SP_GetSBP_Projection_Result, Models.SP_Get_BlotterProjection_Result>();

            Mapper.CreateMap<Models.SBP_BlotterProjection, DataAccessLayer.SBP_BlotterProjection>();
            Mapper.CreateMap<DataAccessLayer.SBP_BlotterProjection, Models.SBP_BlotterProjection>();

        }
        public TDestination Translate(TSource obj)
        {
            return Mapper.Map<TDestination>(obj);
        }
    }
}