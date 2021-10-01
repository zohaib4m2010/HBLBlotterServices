using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace WebApiServices.Repository
{
    public class EntitiyMapperBlotterDMMO<TSource, TDestination> where TSource : class where TDestination : class
    {
        public EntitiyMapperBlotterDMMO()
        {
            
            Mapper.CreateMap<Models.SP_GetSBP_DMMO_Result, DataAccessLayer.SP_GetSBP_DMMO_Result>();
            Mapper.CreateMap<DataAccessLayer.SP_GetSBP_DMMO_Result, Models.SP_GetSBP_DMMO_Result>();

            Mapper.CreateMap<Models.SBP_BlotterDMMO, DataAccessLayer.SBP_BlotterDMMO>();
            Mapper.CreateMap<DataAccessLayer.SBP_BlotterDMMO, Models.SBP_BlotterDMMO>();

        }
        public TDestination Translate(TSource obj)
        {
            return Mapper.Map<TDestination>(obj);
        }
    }
}