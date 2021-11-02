using AutoMapper;
using Samson.Web.Application.Api.Requests.GymObject;
using Samson.Web.Application.Commands.GymObject;

namespace Samson.Web.Application.Api.MapperProfiles
{
    public class GymObjectMapperProfile : Profile
    {
        public GymObjectMapperProfile()
        {
            CreateMap<CreateGymObjectRequest, CreateGymObjectCommand>();
            CreateMap<UpdateGymObjectRequest, UpdateGymObjectCommand>();
            CreateMap<DeleteGymObjectRequest, DeleteGymObjectCommand>();
        }
    }
}
