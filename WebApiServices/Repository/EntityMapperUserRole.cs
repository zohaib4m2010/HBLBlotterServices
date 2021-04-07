﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiServices.Repository
{
    public class EntityMapperUserRole<TSource, TDestination> where TSource : class where TDestination : class
    {
        public EntityMapperUserRole()
        {

            Mapper.CreateMap<Models.UserRole, DataAccessLayer.UserRole>();
            Mapper.CreateMap<DataAccessLayer.UserRole, Models.UserRole>();
        }
        public TDestination Translate(TSource obj)
        {
            return Mapper.Map<TDestination>(obj);
        }
    }
}