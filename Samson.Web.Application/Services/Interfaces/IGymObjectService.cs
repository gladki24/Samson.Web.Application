using System.Threading.Tasks;
using MongoDB.Bson;
using Samson.Web.Application.Models.DataStructures.GymObject;

namespace Samson.Web.Application.Services.Interfaces
{
    /// <summary>
    /// Services to work with GymObject aggregate.
    /// </summary>
    public interface IGymObjectService
    {
        /// <summary>
        /// CreatePersonalTrainer GymObject aggregate.
        /// </summary>
        /// <param name="dataStructure">Data to create GymObject domain</param>
        /// <returns>GymObject Id</returns>
        Task<ObjectId> Create(CreateGymObjectDataStructure dataStructure);

        /// <summary>
        /// Update GymObject aggregate.
        /// </summary>
        /// <param name="dataStructure">Data to update GymObject domain</param>
        /// <returns>GymObject Id</returns>
        Task<ObjectId> Update(UpdateGymObjectDataStructure dataStructure);

        /// <summary>
        /// Delete GymObject aggregate.
        /// </summary>
        /// <param name="id">Id of GymObject</param>
        /// <returns>Deleted GymObject Id</returns>
        Task<ObjectId> Delete(ObjectId id);

        /// <summary>
        /// Add GymRoom to GymObject
        /// </summary>
        /// <param name="dataStructure">Data to add GymRoom to GymObject</param>
        /// <returns>GymRoom Id</returns>
        Task<ObjectId> AddRoom(AddGymRoomDataStructure dataStructure);

        /// <summary>
        /// Remove GymRoom from GymObject
        /// </summary>
        /// <param name="dataStructure">Data to find GymRoom and delete from GymObject</param>
        /// <returns>Deleted GymRoom Id</returns>
        Task<ObjectId> RemoveRoom(RemoveGymRoomDataStructure dataStructure);
    }
}
