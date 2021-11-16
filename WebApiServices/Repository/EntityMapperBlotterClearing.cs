using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiServices.Repository
{
    public class EntityMapperBlotterClearing<TSource, TDestination> where TSource : class where TDestination : class
    {
        public EntityMapperBlotterClearing()
        {
            Mapper.CreateMap<Models.SP_GETAllTransactionTitles_Result, DataAccessLayer.SP_GETAllClearingTransactionTitles_Result>();
            Mapper.CreateMap<DataAccessLayer.SP_GETAllClearingTransactionTitles_Result, Models.SP_GETAllTransactionTitles_Result>();

            Mapper.CreateMap<Models.SP_GetAll_SBPBlotterClearing_Result, DataAccessLayer.SP_GetAll_SBPBlotterClearing_Result>();
            Mapper.CreateMap<DataAccessLayer.SP_GetAll_SBPBlotterClearing_Result, Models.SP_GetAll_SBPBlotterClearing_Result>();

            Mapper.CreateMap<Models.SP_GetAll_SBPBlotterClearing_Dashboard_Result, DataAccessLayer.SP_GetAll_SBPBlotterClearing_DashBoard_Result>();
            Mapper.CreateMap<DataAccessLayer.SP_GetAll_SBPBlotterClearing_DashBoard_Result, Models.SP_GetAll_SBPBlotterClearing_Dashboard_Result>();


            Mapper.CreateMap<Models.SBP_BlotterClearing, DataAccessLayer.SBP_BlotterClearing>();
            Mapper.CreateMap<DataAccessLayer.SBP_BlotterClearing, Models.SBP_BlotterClearing>();
        }
        public TDestination Translate(TSource obj)
        {
            return Mapper.Map<TDestination>(obj);
        }
    }
}