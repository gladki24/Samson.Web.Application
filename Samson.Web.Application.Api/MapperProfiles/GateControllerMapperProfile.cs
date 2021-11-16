using AutoMapper;
using Samson.Web.Application.Api.Requests.Gate;
using Samson.Web.Application.Commands.Gate;
using Samson.Web.Application.Models.DataStructures.Gym;

namespace Samson.Web.Application.Api.MapperProfiles
{
    /// <summary>
    /// Mapping profile to map Gate controller related objects.
    /// </summary>
    public class GateControllerMapperProfile : Profile
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public GateControllerMapperProfile()
        {
            CreateMap<EntryRequest, EntryCommand>();
            CreateMap<EntryRequest, ValidEntranceCommand>();
            CreateMap<ExitRequest, ExitCommand>();

            CreateMap<EntryCommand, EntryDataStructure>();
            CreateMap<ValidEntranceCommand, EntryDataStructure>();
            CreateMap<ExitCommand, ExitDataStructure>();
        }
    }
}
