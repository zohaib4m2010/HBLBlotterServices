using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiServices.Repository
{
    public class EntityMapperBlotterDailyFlows<TSource, TDestination> where TSource : class where TDestination : class
    {
        public EntityMapperBlotterDailyFlows()
        {
            Mapper.CreateMap<Models.SP_GETAllTransactionTitles_Result, DataAccessLayer.SP_GETAllTradeTransactionTitles_Result>();
            Mapper.CreateMap<DataAccessLayer.SP_GETAllTradeTransactionTitles_Result, Models.SP_GETAllTransactionTitles_Result>();

            Mapper.CreateMap<Models.SP_GetAll_SBPBlotterTrade_Result, DataAccessLayer.SP_GetAll_SBPBlotterTrade_Result>();
            Mapper.CreateMap<DataAccessLayer.SP_GetAll_SBPBlotterTrade_Result, Models.SP_GetAll_SBPBlotterTrade_Result>();

            Mapper.CreateMap<Models.SP_GetAll_SBPBlotterTrade_Dashboard_Result, DataAccessLayer.SP_GetAll_SBPBlotterTrade_Dashboard_Result>();
            Mapper.CreateMap<DataAccessLayer.SP_GetAll_SBPBlotterTrade_Dashboard_Result, Models.SP_GetAll_SBPBlotterTrade_Dashboard_Result>();

            Mapper.CreateMap<Models.SP_GetAll_SBPBlotterDailyFlows_Dashboard_Result, DataAccessLayer.SP_GetAll_SBPBlotterDailyFlows_Dashboard_Result>();
            Mapper.CreateMap<DataAccessLayer.SP_GetAll_SBPBlotterDailyFlows_Dashboard_Result, Models.SP_GetAll_SBPBlotterDailyFlows_Dashboard_Result>();


            Mapper.CreateMap<Models.SBP_BlotterTrade, DataAccessLayer.SBP_BlotterTrade>();
            Mapper.CreateMap<DataAccessLayer.SBP_BlotterTrade, Models.SBP_BlotterTrade>();
        }
        public TDestination Translate(TSource obj)
        {
            return Mapper.Map<TDestination>(obj);
        }
    }
}