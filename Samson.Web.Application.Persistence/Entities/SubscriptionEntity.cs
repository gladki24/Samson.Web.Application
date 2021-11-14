using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Samson.Web.Application.Infrastructure;

namespace Samson.Web.Application.Persistence.Entities
{
    /// <summary>
    /// Entity of Subscription.
    /// </summary>
    public class SubscriptionEntity : IAggregateRoot
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ObjectId GymPassTypeId { get; set; }
    }
}
