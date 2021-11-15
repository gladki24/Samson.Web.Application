using MongoDB.Bson;

namespace Samson.Web.Application.Models.DataStructures.IndividualTraining
{
    /// <summary>
    /// Data structure to confirm open training by IndividualTrainer.
    /// </summary>
    public class ConfirmIndividualTrainingDataStructure
    {
        public ObjectId IndividualTrainingId { get; set; }
    }
}
