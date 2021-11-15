using MongoDB.Bson;

namespace Samson.Web.Application.Models.DataStructures.IndividualTraining
{
    /// <summary>
    /// Data structure to cancel IndividualTraining.
    /// </summary>
    public class CancelIndividualTrainingDataStructure
    {
        public ObjectId IndividualTrainingId { get; set; }
    }
}
