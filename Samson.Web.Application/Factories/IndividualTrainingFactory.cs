using MongoDB.Bson;
using Samson.Web.Application.Factories.Interfaces;
using Samson.Web.Application.Infrastructure.Attributes;
using Samson.Web.Application.Models.DataStructures.IndividualTraining;
using Samson.Web.Application.Models.Domains;
using Samson.Web.Application.Models.Enums;

namespace Samson.Web.Application.Factories
{
    /// <summary>
    /// Factory to create IndividualTraining model.
    /// </summary>
    [Factory]
    public class IndividualTrainingFactory : IIndividualTrainingFactory
    {
        /// <summary>
        /// Create IndividualTraining model with id generation
        /// </summary>
        /// <param name="dataStructure">Information about training</param>
        /// <returns>IndividualTraining</returns>
        public IndividualTraining Create(CreateIndividualTrainingDataStructure dataStructure)
        {
            if (dataStructure.ClientId == null)
                dataStructure.Type = IndividualTrainingType.Open;
            else
                dataStructure.Type = IndividualTrainingType.Pending;

            return new IndividualTraining(ObjectId.GenerateNewId(), dataStructure);
        }
    }
}