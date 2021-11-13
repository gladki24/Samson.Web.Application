using AutoMapper;
using MongoDB.Bson;
using Samson.Web.Application.Api.Requests.ExerciseMachine;
using Samson.Web.Application.Api.ViewModels.ExerciseMachine;
using Samson.Web.Application.Commands.ExerciseMachine;
using Samson.Web.Application.Models.DataStructures.ExerciseMachine;
using Samson.Web.Application.Models.Dtos.ExerciseMachine;
using Samson.Web.Application.Queries.ExerciseMachine;

namespace Samson.Web.Application.Api.MapperProfiles
{
    /// <summary>
    /// Mapping profile to map ExerciseMachine controller realted objects.
    /// </summary>
    public class ExerciseMachineControllerMapperProfile : Profile
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public ExerciseMachineControllerMapperProfile()
        {
            CreateMap<CreateExerciseMachineRequest, CreateExerciseMachineCommand>();
            CreateMap<UpdateExerciseMachineRequest, UpdateExerciseMachineCommand>();
            CreateMap<DeleteExerciseMachineRequest, DeleteExerciseMachineCommand>();

            CreateMap<CreateExerciseMachineCommand, CreateExerciseMachineDataStructure>();
            CreateMap<UpdateExerciseMachineCommand, UpdateExerciseMachineDataStructure>();

            CreateMap<string, GetExerciseMachineByIdQuery>().ConstructUsing((id, context) =>
                new GetExerciseMachineByIdQuery(context.Mapper.Map<string, ObjectId>(id)));

            CreateMap<ExerciseMachineDto, ExerciseMachineViewModel>();
        }
    }
}
