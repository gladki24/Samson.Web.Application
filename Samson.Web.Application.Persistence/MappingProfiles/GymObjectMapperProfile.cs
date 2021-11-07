using AutoMapper;
using Samson.Web.Application.Models.Domains;
using Samson.Web.Application.Models.Dtos.GymObject;
using Samson.Web.Application.Persistence.Entities;

namespace Samson.Web.Application.Persistence.MappingProfiles
{
    /// <summary>
    /// Mapping profile to map GymObject entities and models.
    /// </summary>
    public class GymObjectMapperProfile : Profile
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public GymObjectMapperProfile()
        {
            CreateMap<GymObject, GymObjectEntity>().ReverseMap();
            CreateMap<GymObjectEntity, GymObjectDto>();
            CreateMap<CovidConfigurationEntity, CovidConfigurationDto>();
            CreateMap<GymRoomEntity, GymRoomDto>();
            CreateMap<CovidConfiguration, CovidConfigurationEntity>().ReverseMap();
            CreateMap<GymRoom, GymRoomEntity>().ReverseMap();
        }
    }
}
