using System;
using MongoDB.Bson;
using Samson.Web.Application.Models.Enums;

namespace Samson.Web.Application.Models.DataStructures.IndividualTraining
{
    /// <summary>
    /// Data structure to create new IndividualTraining.
    /// </summary>
    public class CreateIndividualTrainingDataStructure
    {
        public ObjectId PersonalTrainerId { get; set; }
        public ObjectId? ClientId { get; set; }
        public ObjectId GymObjectId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public IndividualTrainingType Type { get; set; }
    }
}
