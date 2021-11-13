using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Samson.Web.Application.Infrastructure;

namespace Samson.Web.Application.Persistence.Entities
{
    /// <summary>
    /// Entity of GymPassType.
    /// </summary>
    public class GymPassTypeEntity : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Duration { get; set; }
    }
}
