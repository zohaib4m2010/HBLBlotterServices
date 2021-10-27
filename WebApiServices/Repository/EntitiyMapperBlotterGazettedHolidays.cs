using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace WebApiServices.Repository
{
    public class EntitiyMapperBlotterGazettedHolidays<TSource, TDestination> where TSource : class where TDestination : class
    {
        public EntitiyMapperBlotterGazettedHolidays()
        {
            Mapper.CreateMap<Models.GazettedHoliday, DataAccessLayer.SP_GetSBPBlotterGH_Result>();
            Mapper.CreateMap<DataAccessLayer.SP_GetSBPBlotterGH_Result, Models.GazettedHoliday>();


            Mapper.CreateMap<Models.GazettedHoliday, DataAccessLayer.SP_GetSBPBlotterGH_Result>();
            Mapper.CreateMap<DataAccessLayer.SP_GetSBPBlotterGH_Result, Models.GazettedHoliday>();

            Mapper.CreateMap<Models.SP_GetSBPBlotterGH_Result, DataAccessLayer.SP_GetSBPBlotterGH_Result>();
            Mapper.CreateMap<DataAccessLayer.SP_GetSBPBlotterGH_Result, Models.SP_GetSBPBlotterGH_Result>();
        }

        public TDestination Translate(TSource obj)
        {
            return Mapper.Map<TDestination>(obj);
        }
    }
}