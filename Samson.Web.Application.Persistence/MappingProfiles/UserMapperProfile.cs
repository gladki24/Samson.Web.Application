﻿using AutoMapper;
using Samson.Web.Application.Models.Domains;
using Samson.Web.Application.Persistence.Entities;

namespace Samson.Web.Application.Persistence.MappingProfiles
{
    /// <summary>
    /// Mapping profile to map User entities and models.
    /// </summary>
    public class UserMapperProfile : Profile
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public UserMapperProfile()
        {
            CreateMap<User, UserEntity>().ReverseMap();
        }
    }
}