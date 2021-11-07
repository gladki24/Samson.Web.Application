using AutoMapper;
using MongoDB.Bson;
using Samson.Web.Application.Api.Requests.GymPass;
using Samson.Web.Application.Api.ViewModels.GymPassType;
using Samson.Web.Application.Commands.GymPass;
using Samson.Web.Application.Models.DataStructures.GymPass;
using Samson.Web.Application.Models.Dtos.GymPass;
using Samson.Web.Application.Queries.GymPass;

namespace Samson.Web.Application.Api.MapperProfiles
{
    /// <summary>
    /// Mapping profile to map GymPassType controller realted objects.
    /// </summary>
    public class GymPassTypeControllerMapperProfile : Profile
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public GymPassTypeControllerMapperProfile()
        {
            CreateMap<CreateGymPassTypeRequest, CreateGymPassTypeCommand>();
            CreateMap<UpdateGymPassTypeRequest, UpdateGymPassTypeCommand>();
            CreateMap<DeleteGymPassTypeRequest, DeleteGymPassTypeCommand>();

            CreateMap<CreateGymPassTypeCommand, CreateGymPassTypeDataStructure>();
            CreateMap<UpdateGymPassTypeCommand, UpdateGymPassTypeDataStructure>();

            CreateMap<string, GetGymPassTypeByIdQuery>().ConstructUsing((id, context) =>
                new GetGymPassTypeByIdQuery(context.Mapper.Map<string, ObjectId>(id)));

            CreateMap<GymPassTypeDto, GymPassTypeViewModel>();
        }
    }
}
