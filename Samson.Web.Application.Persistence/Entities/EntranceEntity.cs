using System;
using MongoDB.Bson;
using Samson.Web.Application.Infrastructure;

namespace Samson.Web.Application.Persistence.Entities
{
    /// <summary>
    /// Entity to represent Entrance aggregate.
    /// </summary>
    public class EntranceEntity : IEntity
    {
        public ObjectId Id { get; set; }
        public ObjectId ClientId { get; set; }
        public ObjectId GymObjectId { get; set; }
        public DateTime EntryDate { get; set; }
    }
}
