using Samson.Web.Application.Models.DataStructures.GymObject;
using Samson.Web.Application.Models.Domains;

namespace Samson.Web.Application.Factories.Interfaces
{
    /// <summary>
    /// Factory to create GymObject domain
    /// </summary>
    public interface IGymObjectFactory
    {
        /// <summary>
        /// Create GymObject from data structure.
        /// </summary>
        /// <param name="dataStructure">Data structure to create GymObject</param>
        /// <returns>GymObject domain</returns>
        GymObject CreateGymObject(CreateGymObjectDataStructure dataStructure);

        /// <summary>
        /// Create GymRoom from data structure.
        /// </summary>
        /// <param name="dataStructure">Data structure to create GymRoom</param>
        /// <returns>GymRoom domain</returns>
        GymRoom CreateGymRoom(AddGymRoomDataStructure dataStructure);
    }
}
