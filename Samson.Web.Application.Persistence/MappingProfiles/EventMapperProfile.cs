using AutoMapper;
using Samson.Web.Application.Models.Domains;
using Samson.Web.Application.Models.Dtos.Event;
using Samson.Web.Application.Persistence.Entities;

namespace Samson.Web.Application.Persistence.MappingProfiles
{
    /// <summary>
    /// Mapping profile to map Event entities and models.
    /// </summary>
    public class EventMapperProfile : Profile
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public EventMapperProfile()
        {
            CreateMap<Event, EventEntity>().ReverseMap();
            CreateMap<EventEntity, EventDto>();
        }
    }
}
