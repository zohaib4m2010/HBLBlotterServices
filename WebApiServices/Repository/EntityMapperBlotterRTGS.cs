using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiServices.Repository
{
    public class EntityMapperBlotterRTGS<TSource, TDestination> where TSource : class where TDestination : class
    {
        public EntityMapperBlotterRTGS()
        {
            Mapper.CreateMap<Models.SP_GETAllTransactionTitles_Result, DataAccessLayer.SP_GETAllRTGSTransactionTitles_Result>();
            Mapper.CreateMap<DataAccessLayer.SP_GETAllRTGSTransactionTitles_Result, Models.SP_GETAllTransactionTitles_Result>();

            Mapper.CreateMap<Models.SP_GetAll_SBPBlotterRTGS_Result, DataAccessLayer.SP_GetAll_SBPBlotterRTGS_Result>();
            Mapper.CreateMap<DataAccessLayer.SP_GetAll_SBPBlotterRTGS_Result, Models.SP_GetAll_SBPBlotterRTGS_Result>();

            Mapper.CreateMap<Models.SP_GetAll_SBPBlotterRTGS_Dashboard_Result, DataAccessLayer.SP_GetAll_SBPBlotterRTGS_Dashboard_Result>();
            Mapper.CreateMap<DataAccessLayer.SP_GetAll_SBPBlotterRTGS_Dashboard_Result, Models.SP_GetAll_SBPBlotterRTGS_Dashboard_Result>();


            Mapper.CreateMap<Models.SBP_BlotterRTGS, DataAccessLayer.SBP_BlotterRTGS>();
            Mapper.CreateMap<DataAccessLayer.SBP_BlotterRTGS, Models.SBP_BlotterRTGS>();
        }
        public TDestination Translate(TSource obj)
        {
            return Mapper.Map<TDestination>(obj);
        }
    }
}