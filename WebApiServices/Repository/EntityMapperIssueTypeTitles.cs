using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiServices.Repository
{
    public class EntityMapperIssueTypeTitles<TSource, TDestination> where TSource : class where TDestination : class
    {
        public EntityMapperIssueTypeTitles()
        {
            Mapper.CreateMap<Models.IssueTypeTitles, DataAccessLayer.GetIssueTypeTitles_Result>();
            Mapper.CreateMap<DataAccessLayer.GetIssueTypeTitles_Result, Models.IssueTypeTitles> ();
        }
        public TDestination Translate(TSource obj)
        {
            return Mapper.Map<TDestination>(obj);
        }
    }
}