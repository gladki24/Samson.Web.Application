using AutoMapper;
using MongoDB.Bson;
using Samson.Web.Application.Api.Requests.IndividualTraining;
using Samson.Web.Application.Api.ViewModels.IndividualTraining;
using Samson.Web.Application.Commands.IndividualTraining;
using Samson.Web.Application.Models.DataStructures.IndividualTraining;
using Samson.Web.Application.Models.Dtos.IndividualTraining;
using Samson.Web.Application.Persistence.Entities;
using Samson.Web.Application.Queries.IndividualTraining;

namespace Samson.Web.Application.Api.MapperProfiles
{
    /// <summary>
    /// Mapping profile to map IndividualTraining controller related objects.
    /// </summary>
    public class IndividualTrainingControllerMapperProfile : Profile
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public IndividualTrainingControllerMapperProfile()
        {
            CreateMap<CreateIndividualTrainingRequest, CreateIndividualTrainingCommand>();
            CreateMap<CreateIndividualTrainingCommand, CreateIndividualTrainingDataStructure>();

            CreateMap<UpdateIndividualTrainingRequest, UpdateIndividualTrainingCommand>();
            CreateMap<UpdateIndividualTrainingCommand, UpdateIndividualTrainingDataStructure>();

            CreateMap<EnrollIndividualTrainingRequest, EnrollIndividualTrainingCommand>();
            CreateMap<EnrollIndividualTrainingCommand, EnrollInIndividualTrainingDataStructure>();

            CreateMap<CancelIndividualTrainingRequest, CancelIndividualTrainingCommand>();
            CreateMap<CancelIndividualTrainingCommand, CancelIndividualTrainingDataStructure>();

            CreateMap<ConfirmIndividualTrainingRequest, ConfirmIndividualTrainingCommand>();
            CreateMap<ConfirmIndividualTrainingCommand, ConfirmIndividualTrainingDataStructure>();

            CreateMap<string, GetIndividualTrainingByIdQuery>().ConstructUsing((id, ctx)
                => new GetIndividualTrainingByIdQuery(ctx.Mapper.Map<string, ObjectId>(id)));

            CreateMap<IndividualTrainingEntity, IndividualTrainingDto>();
            CreateMap<IndividualTrainingDto, IndividualTrainingViewModel>();
        }
    }
}
