using AutoMapper;
using Samson.Web.Application.Models.Domains;
using Samson.Web.Application.Persistence.Entities;

namespace Samson.Web.Application.Persistence.MappingProfiles
{
    /// <summary>
    /// Mapping profile to map IndividualTraining related models.
    /// </summary>
    public class IndividualTrainingMapperProfile : Profile
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public IndividualTrainingMapperProfile()
        {
            CreateMap<IndividualTraining, IndividualTrainingEntity>().ReverseMap();
        }
    }
}
