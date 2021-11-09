using AutoMapper;
using MongoDB.Bson;
using Samson.Web.Application.Api.Requests.GymObject;
using Samson.Web.Application.Api.ViewModels.GymObject;
using Samson.Web.Application.Commands.GymObject;
using Samson.Web.Application.Models.DataStructures.GymObject;
using Samson.Web.Application.Models.Dtos.GymObject;
using Samson.Web.Application.Queries.GymObject;

namespace Samson.Web.Application.Api.MapperProfiles
{
    /// <summary>
    /// Mapping profile to map GymObject controller related objects.
    /// </summary>
    public class GymObjectControllerMapperProfile : Profile
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public GymObjectControllerMapperProfile()
        {
            CreateMap<CreateGymObjectRequest, CreateGymObjectCommand>();
            CreateMap<UpdateGymObjectRequest, UpdateGymObjectCommand>();
            CreateMap<DeleteGymObjectRequest, DeleteGymObjectCommand>();

            CreateMap<CreateGymObjectCommand, CreateGymObjectDataStructure>();
            CreateMap<UpdateGymObjectCommand, UpdateGymObjectDataStructure>();

            CreateMap<CovidConfigurationRequest, CovidConfigurationDataStructure>();
            CreateMap<RoomConfigurationRequest, RoomConfigurationDataStructure>();

            CreateMap<string, GymObjectQuery>().ConstructUsing((id, ctx) =>
                new GymObjectQuery(ctx.Mapper.Map<string, ObjectId>(id)));

            CreateMap<GymRoomDto, GymRoomViewModel>();
            CreateMap<GymObjectDto, GymObjectViewModel>();
            CreateMap<CovidConfigurationDto, CovidConfigurationViewModel>();

            CreateMap<AddGymRoomRequest, AddGymRoomCommand>();
            CreateMap<RemoveGymRoomRequest, RemoveGymRoomCommand>();

            CreateMap<AddGymRoomCommand, AddGymRoomDataStructure>();
            CreateMap<RemoveGymRoomCommand, RemoveGymRoomDataStructure>();
        }
    }
}
