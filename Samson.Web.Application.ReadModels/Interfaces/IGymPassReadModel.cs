using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using Samson.Web.Application.Models.Dtos.GymPass;

namespace Samson.Web.Application.ReadModels.Interfaces
{
    /// <summary>
    /// Read model to get GymPassType dtos.
    /// </summary>
    public interface IGymPassReadModel
    {
        /// <summary>
        /// Get GymPassType from collection by id.
        /// </summary>
        /// <param name="id">Key</param>
        /// <returns>Dto</returns>
        Task<GymPassTypeDto> GetById(ObjectId id);

        /// <summary>
        /// Get all GypPassTypes from collection.
        /// </summary>
        /// <returns>Dtos list</returns>
        Task<List<GymPassTypeDto>> GetAll();
    }
}
