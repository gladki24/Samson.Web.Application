using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using Samson.Web.Application.Models.Dtos.GymObject;

namespace Samson.Web.Application.ReadModels.Interfaces
{
    /// <summary>
    /// Read model to get GymObject dtos.
    /// </summary>
    public interface IGymObjectReadModel
    {
        /// <summary>
        /// Get GymObject from collection by id.
        /// </summary>
        /// <param name="id">key</param>
        /// <returns>dto</returns>
        Task<GymObjectDto> GetById(ObjectId id);

        /// <summary>
        /// Get all GymObjects from collection.
        /// </summary>
        /// <returns>dtos list</returns>
        Task<List<GymObjectDto>> GetAll();

    }
}
