using MediatR;
using MongoDB.Bson;
using Samson.Web.Application.Models.Dtos.Event;

namespace Samson.Web.Application.Queries.Event
{
    /// <summary>
    /// Query to get Event by id.
    /// </summary>
    public class GetEventByIdQuery : IRequest<EventDto>
    {
        public ObjectId Id { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="id">Key</param>
        public GetEventByIdQuery(ObjectId id)
        {
            Id = id;
        }
    }
}
