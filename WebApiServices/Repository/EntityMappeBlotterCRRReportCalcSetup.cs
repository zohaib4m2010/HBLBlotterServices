using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiServices.Repository
{
    public class EntityMappeBlotterCRRReportCalcSetup<TSource, TDestination> where TSource : class where TDestination : class
    {
        public EntityMappeBlotterCRRReportCalcSetup()
        {
           

            Mapper.CreateMap<Models.SP_GETAll_MAX_BlotterCRRReportCalcSetup_Result, DataAccessLayer.SP_GETAll_MAX_BlotterCRRReportCalcSetup_Result>();
            Mapper.CreateMap<DataAccessLayer.SP_GETAll_MAX_BlotterCRRReportCalcSetup_Result, Models.SP_GETAll_MAX_BlotterCRRReportCalcSetup_Result>();

     

            Mapper.CreateMap<Models.SBP_BlotterCRRReportCalcSetup, DataAccessLayer.SBP_BlotterCRRReportCalcSetup>();
            Mapper.CreateMap<DataAccessLayer.SBP_BlotterCRRReportCalcSetup, Models.SBP_BlotterCRRReportCalcSetup>();
        }
        public TDestination Translate(TSource obj)
        {
            return Mapper.Map<TDestination>(obj);
        }
    }
}