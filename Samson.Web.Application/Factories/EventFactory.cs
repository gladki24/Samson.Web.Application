using MongoDB.Bson;
using Samson.Web.Application.Factories.Interfaces;
using Samson.Web.Application.Infrastructure.Attributes;
using Samson.Web.Application.Models.DataStructures.Event;
using Samson.Web.Application.Models.Domains;

namespace Samson.Web.Application.Factories
{
    /// <summary>
    /// Factory to create event model
    /// </summary>
    [Factory]
    public class EventFactory : IEventFactory
    {
        /// <summary>
        /// Create Event model with id generation
        /// </summary>
        /// <param name="dataStructure">Information about event</param>
        /// <returns>Event</returns>
        public Event CreateEvent(CreateEventDataStructure dataStructure)
            => new Event(ObjectId.GenerateNewId(), dataStructure);
    }
}
