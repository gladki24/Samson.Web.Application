using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Samson.Web.Application.Infrastructure;
using Samson.Web.Application.Models.Enums;

namespace Samson.Web.Application.Persistence.Entities
{
    /// <summary>
    /// Entity of IndividualTraining.
    /// </summary>
    public class IndividualTrainingEntity : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        public ObjectId PersonalTrainerId { get; set; }
        public ObjectId? ClientId { get; set; }
        public ObjectId GymObjectId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public IndividualTrainingType Type { get; set; }
    }
}
