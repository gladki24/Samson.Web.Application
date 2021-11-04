using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Samson.Web.Application.Infrastructure;

namespace Samson.Web.Application.Persistence.Entities
{
    /// <summary>
    /// Entity of GymObject
    /// </summary>
    public class GymObjectEntity : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public CovidConfigurationEntity CovidConfiguration { get; set; }
        public IEnumerable<GymRoomEntity> Rooms { get; set; }
    }
}
