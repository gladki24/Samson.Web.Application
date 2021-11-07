using MongoDB.Bson;
using Samson.Web.Application.Factories.Interfaces;
using Samson.Web.Application.Infrastructure.Attributes;
using Samson.Web.Application.Infrastructure.Repository;
using Samson.Web.Application.Models.DataStructures.Event;
using Samson.Web.Application.Models.Domains;
using Samson.Web.Application.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace Samson.Web.Application.Services
{
    /// <summary>
    /// Application service to work with Event
    /// </summary>
    [Service]
    public class EventService : IEventService
    {
        private readonly IRepository<Event> _repository;
        private readonly IEventFactory _factory;

        public EventService(IRepository<Event> repository, IEventFactory factory)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        public Task<ObjectId> Create(CreateEventDataStructure dataStructure)
        {
            var @event = _factory.CreateEvent(dataStructure);
            return _repository.Create(@event);
        }

        public Task<ObjectId> Delete(ObjectId id)
        {
            var @event = GetOrThrow(id);
            return _repository.Remove(@event);
        }

        public Task<ObjectId> Update(UpdateEventDataStructure dataStructure)
        {
            var @event = GetOrThrow(dataStructure.Id);
            @event.Update(dataStructure);
            return _repository.Update(dataStructure.Id, @event);
        }

        private Event GetOrThrow(ObjectId id)
        {
            return _repository.Get(id) ?? throw new ApplicationException("Event not found");
        }
    }
}
