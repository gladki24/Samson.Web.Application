using Samson.Web.Application.Models.DataStructures.GymPass;
using Samson.Web.Application.Models.Domains;

namespace Samson.Web.Application.Factories.Interfaces
{
    /// <summary>
    /// Factory to create GymPassType domain.
    /// </summary>
    public interface IGymPassTypeFactory
    {
        /// <summary>
        /// CreatePersonalTrainer GymPassType from data structure.
        /// </summary>
        /// <param name="dataStructure">Data structure to create GymPassType</param>
        /// <returns>GymPassType domain</returns>
        GymPassType CreateGymPassType(CreateGymPassTypeDataStructure dataStructure);
    }
}
