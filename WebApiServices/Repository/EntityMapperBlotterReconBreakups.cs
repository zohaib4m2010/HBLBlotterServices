using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiServices.Repository
{
    public class EntityMapperBlotterReconBreakups<TSource, TDestination> where TSource : class where TDestination : class
    {

        public EntityMapperBlotterReconBreakups()
        {
            Mapper.CreateMap<Models.SP_GETAllTransactionTitles_Result, DataAccessLayer.SP_GETAllRECONBreakupsTransactionTitles_Result>();
            Mapper.CreateMap<DataAccessLayer.SP_GETAllRECONBreakupsTransactionTitles_Result, Models.SP_GETAllTransactionTitles_Result>();

            Mapper.CreateMap<Models.SP_GetAll_SBPBlotterReconBreakups_Results, DataAccessLayer.SP_GetAll_SBPBlotterReconBreakups_Result>();
            Mapper.CreateMap<DataAccessLayer.SP_GetAll_SBPBlotterReconBreakups_Result, Models.SP_GetAll_SBPBlotterReconBreakups_Results>();


            Mapper.CreateMap<Models.SP_GetAll_SBPBlotterReconBreakups_Results_Dashboard, DataAccessLayer.SP_GetAll_SBPBlotterReconBreakups_Dashboard_Result>();
            Mapper.CreateMap<DataAccessLayer.SP_GetAll_SBPBlotterReconBreakups_Dashboard_Result, Models.SP_GetAll_SBPBlotterReconBreakups_Results_Dashboard>();


            Mapper.CreateMap<Models.SBP_BlotterReconBreakups, DataAccessLayer.SBP_BlotterReconBreakups>();
            Mapper.CreateMap<DataAccessLayer.SBP_BlotterReconBreakups, Models.SBP_BlotterReconBreakups>();
        }
        public TDestination Translate(TSource obj)
        {
            return Mapper.Map<TDestination>(obj);
        }
    }
}