using AutoMapper;
using Samson.Web.Application.Models.Domains;
using Samson.Web.Application.Models.Dtos.GymPass;
using Samson.Web.Application.Persistence.Entities;

namespace Samson.Web.Application.Persistence.MappingProfiles
{
    /// <summary>
    /// Mapping profile to map GymPassType entities and models.
    /// </summary>
    public class GymPassTypeMapperProfile : Profile
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public GymPassTypeMapperProfile()
        {
            CreateMap<GymPassType, GymPassTypeEntity>().ReverseMap();
            CreateMap<GymPassTypeEntity, GymPassTypeDto>();
        }
    }
}
