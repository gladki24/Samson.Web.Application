using AutoMapper;
using Samson.Web.Application.Models.Domains;
using Samson.Web.Application.Persistence.Entities;

namespace Samson.Web.Application.Persistence.MappingProfiles
{
    /// <summary>
    /// Mapper to map between entrance aggregate related objects.
    /// </summary>
    public class EntranceMapperProfile : Profile
    {
        public EntranceMapperProfile()
        {
            CreateMap<Entrance, EntranceEntity>().ReverseMap();
        }
    }
}
