using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiServices.Models;
using WebApiServices.Repository;

namespace WebApiServices.Repository
{
    public class EntitiyMapperBlotterFR<TSource, TDestination> where TSource : class where TDestination : class
    {
        public EntitiyMapperBlotterFR()
        {
            Mapper.CreateMap<Models.SBP_BlotterFundingRepo, DataAccessLayer.SBP_BlotterFundingRepo>();
            Mapper.CreateMap<DataAccessLayer.SBP_BlotterFundingRepo, Models.SBP_BlotterFundingRepo>();

            Mapper.CreateMap<Models.SP_GetSBPBlotterFRAuto_Result, DataAccessLayer.SP_GetSBPBlotterFRAuto_Result>();
            Mapper.CreateMap<DataAccessLayer.SP_GetSBPBlotterFRAuto_Result, Models.SP_GetSBPBlotterFRAuto_Result>();

            Mapper.CreateMap<Models.SP_GetSBPBlotterFR_Result, DataAccessLayer.SP_GetSBPBlotterFR_Result>();
            Mapper.CreateMap<DataAccessLayer.SP_GetSBPBlotterFR_Result, Models.SP_GetSBPBlotterFR_Result>();
        }

        public TDestination Translate(TSource obj)
        {
            return Mapper.Map<TDestination>(obj);
        }
    }
}