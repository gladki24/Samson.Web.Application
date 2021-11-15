using Samson.Web.Application.Models.DataStructures.GymPass;
using Samson.Web.Application.Models.Domains;

namespace Samson.Web.Application.Factories.Interfaces
{
    /// <summary>
    /// Factory to create GymPassType aggregate.
    /// </summary>
    public interface IGymPassTypeFactory
    {
        /// <summary>
        /// Create GymPassType from data structure.
        /// </summary>
        /// <param name="dataStructure">Data structure to create GymPassType</param>
        /// <returns>GymPassType aggregate</returns>
        GymPassType CreateGymPassType(CreateGymPassTypeDataStructure dataStructure);
    }
}
