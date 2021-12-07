using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiServices.Repository
{
    public class EntityMapperBlotterOR<TSource, TDestination> where TSource : class where TDestination : class
    {
        public EntityMapperBlotterOR()
        {

            Mapper.CreateMap<Models.SBP_BlotterOutRight, DataAccessLayer.SBP_BlotterOutrights>();
            Mapper.CreateMap<DataAccessLayer.SBP_BlotterOutrights, Models.SBP_BlotterOutRight>();

            Mapper.CreateMap<Models.SBP_BlotterOutRight, DataAccessLayer.SP_GetSBPBlotterOutRright_Result>();
            Mapper.CreateMap<DataAccessLayer.SP_GetSBPBlotterOutRright_Result, Models.SBP_BlotterOutRight>();


            Mapper.CreateMap<Models.SP_GetSBPBlotterOR_Result, DataAccessLayer.SP_GetSBPBlotterOutRright_Result>();
            Mapper.CreateMap<DataAccessLayer.SP_GetSBPBlotterOutRright_Result, Models.SP_GetSBPBlotterOR_Result>();

            Mapper.CreateMap<Models.SP_GetSBPBlotterOR_Result, DataAccessLayer.SP_GetSBPBlotterOutRrightAuto_Result>();
            Mapper.CreateMap<DataAccessLayer.SP_GetSBPBlotterOutRrightAuto_Result, Models.SP_GetSBPBlotterOR_Result>();
        }
        public TDestination Translate(TSource obj)
        {
            return Mapper.Map<TDestination>(obj);
        }
    }
}