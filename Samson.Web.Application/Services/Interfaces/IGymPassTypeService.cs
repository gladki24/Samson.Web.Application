using System.Threading.Tasks;
using MongoDB.Bson;
using Samson.Web.Application.Models.DataStructures.GymPass;

namespace Samson.Web.Application.Services.Interfaces
{
    /// <summary>
    /// Services to work with GymPassType domain.
    /// </summary>
    public interface IGymPassTypeService
    {
        /// <summary>
        /// Create GymPassType domain.
        /// </summary>
        /// <param name="dataStructure">Data to create GymPassType domain</param>
        /// <returns>GymPassType Id</returns>
        Task<ObjectId> Create(CreateGymPassTypeDataStructure dataStructure);

        /// <summary>
        /// Update GymPassType domain.
        /// </summary>
        /// <param name="dataStructure">Data to update GymPassType domain</param>
        /// <returns>GymPassType Id</returns>
        Task<ObjectId> Update(UpdateGymPassTypeDataStructure dataStructure);

        /// <summary>
        /// Delete GymPassType domain.
        /// </summary>
        /// <param name="id">Id of GymPassType domain</param>
        /// <returns>GymPassType Id</returns>
        Task<ObjectId> Delete(ObjectId id);
    }
}
