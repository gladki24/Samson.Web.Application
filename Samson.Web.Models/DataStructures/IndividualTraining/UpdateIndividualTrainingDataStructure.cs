using System;
using MongoDB.Bson;

namespace Samson.Web.Application.Models.DataStructures.IndividualTraining
{
    /// <summary>
    /// Data structure to edit details about IndividualTraining.
    /// </summary>
    public class UpdateIndividualTrainingDataStructure
    {
        public ObjectId IndividualTrainingId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ObjectId GymObjectId { get; set; }
    }
}
