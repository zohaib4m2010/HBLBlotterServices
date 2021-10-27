using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiServices.Repository
{
    public class EntityMapperBlotterFCY<TSource, TDestination> where TSource : class where TDestination : class
    {
        public EntityMapperBlotterFCY()
        {
            //Mapper.CreateMap<Models.SP_SBPBlotter_FCY_Result, DataAccessLayer.SP_SBPBlotter_FCY_Result>();
            //Mapper.CreateMap<DataAccessLayer.SP_SBPBlotter_FCY_Result, Models.SP_SBPBlotter_FCY_Result>();
        }

        public TDestination Translate(TSource obj)
        {
            return Mapper.Map<TDestination>(obj);
        }
    }
}