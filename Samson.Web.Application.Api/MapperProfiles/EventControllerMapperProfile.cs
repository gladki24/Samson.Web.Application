using AutoMapper;
using MongoDB.Bson;
using Samson.Web.Application.Api.Requests.Event;
using Samson.Web.Application.Api.ViewModels.Event;
using Samson.Web.Application.Commands.Event;
using Samson.Web.Application.Models.DataStructures.Event;
using Samson.Web.Application.Models.Dtos.Event;
using Samson.Web.Application.Queries.Event;

namespace Samson.Web.Application.Api.MapperProfiles
{
    /// <summary>
    /// Mapping profile to map Event controller related objects.
    /// </summary>
    public class EventControllerMapperProfile : Profile
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public EventControllerMapperProfile()
        {
            CreateMap<CreateEventRequest, CreateEventCommand>();
            CreateMap<UpdateEventRequest, UpdateEventCommand>();
            CreateMap<DeleteEventRequest, DeleteEventCommand>();

            CreateMap<CreateEventCommand, CreateEventDataStructure>();
            CreateMap<UpdateEventCommand, UpdateEventDataStructure>();

            CreateMap<string, GetEventByIdQuery>().ConstructUsing((id, context) =>
                new GetEventByIdQuery(context.Mapper.Map<string, ObjectId>(id)));

            CreateMap<EventDto, EventViewModel>();
        }

    }
}
