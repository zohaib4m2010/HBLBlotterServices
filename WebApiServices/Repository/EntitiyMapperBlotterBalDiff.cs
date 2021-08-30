using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiServices.Repository
{
    public class EntitiyMapperBlotterBalDiff<TSource, TDestination> where TSource : class where TDestination : class
    {
        public EntitiyMapperBlotterBalDiff()
        {
            Mapper.CreateMap<Models.SBP_BlotterOpeningClosingBalanceDIfferential, DataAccessLayer.SBP_BlotterOpeningClosingBalanceDIfferential>();
            Mapper.CreateMap<DataAccessLayer.SBP_BlotterOpeningClosingBalanceDIfferential, Models.SBP_BlotterOpeningClosingBalanceDIfferential>();

            Mapper.CreateMap<Models.SBP_BlotterOpeningClosingBalanceDIfferential, DataAccessLayer.SP_GetSBPBlotterOpeningClosingBalanceDIfferential_Result>();
            Mapper.CreateMap<DataAccessLayer.SBP_BlotterOpeningClosingBalanceDIfferential, Models.SBP_BlotterOpeningClosingBalanceDIfferential>();

            Mapper.CreateMap<Models.SP_GetSBPBlotterOpeningClosingBalanceDIfferential_Result, DataAccessLayer.SP_GetSBPBlotterOpeningClosingBalanceDIfferential_Result>();
            Mapper.CreateMap<DataAccessLayer.SP_GetSBPBlotterOpeningClosingBalanceDIfferential_Result, Models.SP_GetSBPBlotterOpeningClosingBalanceDIfferential_Result>();

        }
        public TDestination Translate(TSource obj)
        {
            return Mapper.Map<TDestination>(obj);
        }
    }
}