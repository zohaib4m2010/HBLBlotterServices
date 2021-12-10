using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiServices.Repository
{
    public class EntityMapperBlotterSheduler<TSource, TDestination> where TSource : class where TDestination : class
    {
        public EntityMapperBlotterSheduler()
        {
            Mapper.CreateMap<Models.SP_GetSBPBlotterGetSheduler_Result, DataAccessLayer.SP_GetSBPBlotterGetSheduler_Result>();
            Mapper.CreateMap<DataAccessLayer.SP_GetSBPBlotterGetSheduler_Result, Models.SP_GetSBPBlotterGetSheduler_Result>();

        

   

            Mapper.CreateMap<Models.BlotterSBP_Sheduler, DataAccessLayer.BlotterSBP_Sheduler>();
            Mapper.CreateMap<DataAccessLayer.BlotterSBP_Sheduler, Models.BlotterSBP_Sheduler>();
        }
        public TDestination Translate(TSource obj)
        {
            return Mapper.Map<TDestination>(obj);
        }
    }
}