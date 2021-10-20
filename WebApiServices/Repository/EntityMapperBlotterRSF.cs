using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiServices.Repository
{
    public class EntityMapperBlotterRSF<TSource, TDestination> where TSource : class where TDestination : class
    {
        public EntityMapperBlotterRSF()
        {
            Mapper.CreateMap<Models.BlotterRSFTT, DataAccessLayer.SP_GetAllRsfTTTBO_Result>();
            Mapper.CreateMap<DataAccessLayer.SP_GetAllRsfTTTBO_Result, Models.BlotterRSFTT>();
        }
        public TDestination Translate(TSource obj)
        {
            return Mapper.Map<TDestination>(obj);
        }
    }
}