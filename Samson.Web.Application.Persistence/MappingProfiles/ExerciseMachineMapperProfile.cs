using AutoMapper;
using Samson.Web.Application.Models.Domains;
using Samson.Web.Application.Models.Dtos.ExerciseMachine;
using Samson.Web.Application.Models.Dtos.GymObject;
using Samson.Web.Application.Persistence.Entities;

namespace Samson.Web.Application.Persistence.MappingProfiles
{
    /// <summary>
    /// Mapping profile to map ExerciseMachine entities and models.
    /// </summary>
    public class ExerciseMachineMapperProfile : Profile
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public ExerciseMachineMapperProfile()
        {
            CreateMap<ExerciseMachine, ExerciseMachineEntity>().ReverseMap();
        }
    }
}
