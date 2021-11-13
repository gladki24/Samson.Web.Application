using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Samson.Web.Application.Infrastructure;
using Samson.Web.Application.Models.Enums;

namespace Samson.Web.Application.Persistence.Entities
{
    /// <summary>
    /// Entity of ExerciseMachine.
    /// </summary>
    public class ExerciseMachineEntity : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public MachineType Type { get; set; }
        public ObjectId LocalizationGymObjectId { get; set; }
    }
}
