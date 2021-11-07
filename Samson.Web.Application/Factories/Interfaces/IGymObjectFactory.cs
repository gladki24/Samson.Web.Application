using Samson.Web.Application.Models.DataStructures;
using Samson.Web.Application.Models.Domains;

namespace Samson.Web.Application.Factories.Interfaces
{
    /// <summary>
    /// Factory to create GymObject domain
    /// </summary>
    public interface IGymObjectFactory
    {
        /// <summary>
        /// Create gym object from data structure
        /// </summary>
        /// <param name="dataStructure">Data structure to create gym object</param>
        /// <returns>GymObject domain</returns>
        GymObject CreateGymObject(CreateGymObjectDataStructure dataStructure);
    }
}
