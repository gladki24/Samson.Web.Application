using MongoDB.Bson;

namespace Samson.Web.Application.Models.DataStructures.IndividualTraining
{
    /// <summary>
    /// Data structure to enroll Client in IndividualTraining.
    /// </summary>
    public class EnrollInIndividualTrainingDataStructure
    {
        public ObjectId IndividualTrainingId { get; set; }
        public ObjectId ClientId { get; set; }
    }
}
