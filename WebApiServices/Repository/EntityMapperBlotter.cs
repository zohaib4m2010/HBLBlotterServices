using AutoMapper;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiServices.Repository
{
    class EntityMapperBlotter<TSource, TDestination> where TSource : class where TDestination : class
    {

        public EntityMapperBlotter()
        {
            Mapper.CreateMap<Models.SP_SBPBlotter_Result, DataAccessLayer.SP_SBPBlotter_Result>();
            Mapper.CreateMap<DataAccessLayer.SP_SBPBlotter_Result, Models.SP_SBPBlotter_Result>();


            Mapper.CreateMap<Models.SBP_BlotterOpeningBalance, DataAccessLayer.SP_GetOpeningBalance_Result>();
            Mapper.CreateMap<DataAccessLayer.SP_GetOpeningBalance_Result, Models.SBP_BlotterOpeningBalance>();



            Mapper.CreateMap<Models.SP_GETLatestBlotterDTLReportDayWise_Result, DataAccessLayer.SP_GETLatestBlotterDTLReportDayWise_Result>();
            Mapper.CreateMap<DataAccessLayer.SP_GETLatestBlotterDTLReportDayWise_Result, Models.SP_GETLatestBlotterDTLReportDayWise_Result>();

            Mapper.CreateMap<Models.SP_GETLatestBlotterDTLReportDayWise_Result, DataAccessLayer.SP_GETLatestBlotterDTLReportForToday_Result>();
            Mapper.CreateMap<DataAccessLayer.SP_GETLatestBlotterDTLReportForToday_Result, Models.SP_GETLatestBlotterDTLReportDayWise_Result>();

            Mapper.CreateMap<Models.SP_GETLatestBlotterDTLPerDayWise_Result, DataAccessLayer.SP_GETLatestBlotterDTLPerDayWise_Result>();
            Mapper.CreateMap<DataAccessLayer.SP_GETLatestBlotterDTLPerDayWise_Result, Models.SP_GETLatestBlotterDTLPerDayWise_Result>();


            Mapper.CreateMap<Models.SP_GetOPICSManualData_Result, DataAccessLayer.SP_GetOPICSManualData_Result>();
            Mapper.CreateMap<DataAccessLayer.SP_GetOPICSManualData_Result, Models.SP_GetOPICSManualData_Result>();


            Mapper.CreateMap<Models.SP_GetOPICSManualData_Result, DataAccessLayer.SP_ReconcileOPICSManualData_Result>();
            Mapper.CreateMap<DataAccessLayer.SP_ReconcileOPICSManualData_Result, Models.SP_GetOPICSManualData_Result>();
        }
      
        public TDestination Translate(TSource obj)
        {
            return Mapper.Map<TDestination>(obj);
        }
    }
}
