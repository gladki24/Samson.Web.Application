using System.Threading.Tasks;
using MediatR;
using MongoDB.Bson;
using Samson.Web.Application.Models.DataStructures;

namespace Samson.Web.Application.Services.Interfaces
{
    /// <summary>
    /// Services to work with GymObject domain
    /// </summary>
    public interface IGymObjectService
    {
        /// <summary>
        /// Create GymObject domain
        /// </summary>
        /// <param name="dataStructure">Data to create GymObject domain</param>
        /// <returns>GymObject Id</returns>
        Task<ObjectId> Create(CreateGymObjectDataStructure dataStructure);

        /// <summary>
        /// Update GymObject domain
        /// </summary>
        /// <param name="dataStructure">Data to update GymObject domain</param>
        /// <returns>GymObject Id</returns>
        Task<ObjectId> Update(UpdateGymObjectDataStructure dataStructure);

        /// <summary>
        /// Delete GymObject domain
        /// </summary>
        /// <param name="id">Id of GymObject</param>
        /// <returns>GymObject Id</returns>
        Task<ObjectId> Delete(ObjectId id);
    }
}
