using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiServices.Repository
{
    public class EntitiyMapperBlotterCRRFINCONPeriods<TSource, TDestination> where TSource : class where TDestination : class
    {
        public EntitiyMapperBlotterCRRFINCONPeriods()
        {

            Mapper.CreateMap<Models.SBP_BlotterCRRFINCONPeriods, DataAccessLayer.SP_GetCRRFINCONPeriods_Result>();
            Mapper.CreateMap<DataAccessLayer.SP_GetCRRFINCONPeriods_Result, Models.SBP_BlotterCRRFINCONPeriods>();

        }
        public TDestination Translate(TSource obj)
        {
            return Mapper.Map<TDestination>(obj);
        }
    }
}