using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiServices.Repository
{
    class EntitiyMapperBlotterTBO<TSource, TDestination> where TSource : class where TDestination : class
    {
        public EntitiyMapperBlotterTBO()
        {
            Mapper.CreateMap<Models.SP_GETAllTransactionTitles_Result, DataAccessLayer.SP_GETAllTBOTransactionTitles_Result>();
            Mapper.CreateMap<DataAccessLayer.SP_GETAllTBOTransactionTitles_Result, Models.SP_GETAllTransactionTitles_Result>();

            Mapper.CreateMap<Models.SP_GetAll_SBPBlotterTBO_Result, DataAccessLayer.SP_GetAll_SBPBlotterTBO_Result>();
            Mapper.CreateMap<DataAccessLayer.SP_GetAll_SBPBlotterTBO_Result, Models.SP_GetAll_SBPBlotterTBO_Result>();


              Mapper.CreateMap<Models.SP_GetAll_SBPBlotterTBO_Dashboard_Result, DataAccessLayer.SP_GetAll_SBPBlotterTBO_DashBoard_Result>();
            Mapper.CreateMap<DataAccessLayer.SP_GetAll_SBPBlotterTBO_DashBoard_Result, Models.SP_GetAll_SBPBlotterTBO_Dashboard_Result>();

            Mapper.CreateMap<Models.SBP_BlotterTBO, DataAccessLayer.SBP_BlotterTBO>();
            Mapper.CreateMap<DataAccessLayer.SBP_BlotterTBO, Models.SBP_BlotterTBO>();
        }
        public TDestination Translate(TSource obj)
        {
            return Mapper.Map<TDestination>(obj);
        }
    }
}