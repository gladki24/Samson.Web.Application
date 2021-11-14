using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Samson.Web.Application.Infrastructure;
using System;
using System.Collections.Generic;

namespace Samson.Web.Application.Persistence.Entities
{
    /// <summary>
    /// Entity of Event
    /// </summary>
    public class EventEntity : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int MaximumParticipants { get; set; }
        public IEnumerable<ObjectId> ParticipantsId { get; set; }
        public ObjectId EventSupervisorId { get; set; }
        public ObjectId GymRoomId { get; set; }

        /// <summary>
        /// Empty constructor.
        /// </summary>
        public EventEntity()
        {}
    }
}
