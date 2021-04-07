﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiServices.Repository
{
    public class EntityMapperNostroBank<TSource, TDestination> where TSource : class where TDestination : class
    {
        public EntityMapperNostroBank()
        {

            Mapper.CreateMap<Models.NostroBank, DataAccessLayer.NostroBank>();
            Mapper.CreateMap<DataAccessLayer.NostroBank, Models.NostroBank>();
        }
        public TDestination Translate(TSource obj)
        {
            return Mapper.Map<TDestination>(obj);
        }
    }
}