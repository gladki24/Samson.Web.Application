using Samson.Web.Application.Models.DataStructures.IndividualTraining;
using Samson.Web.Application.Models.Domains;

namespace Samson.Web.Application.Factories.Interfaces
{
    /// <summary>
    /// Factory to create IndividualTraining aggregate.
    /// </summary>
    public interface IIndividualTrainingFactory
    {
        /// <summary>
        /// Create IndividualTraining from data structure.
        /// </summary>
        /// <param name="dataStructure">Data structure to create IndividualTraining</param>
        /// <returns>IndividualTraining aggregate</returns>
        IndividualTraining Create(CreateIndividualTrainingDataStructure dataStructure);
    }
}
