using MongoDB.Bson;
using Samson.Web.Application.Factories.Interfaces;
using Samson.Web.Application.Infrastructure.Attributes;
using Samson.Web.Application.Models.DataStructures.Event;
using Samson.Web.Application.Models.Domains;

namespace Samson.Web.Application.Factories
{
    [Factory]
    public class EventFactory : IEventFactory
    {
        public Event CreateEvent(CreateEventDataStructure dataStructure)
            => new Event(ObjectId.GenerateNewId(), dataStructure);
    }
}
