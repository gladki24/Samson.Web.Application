using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using Samson.Web.Application.Models.Dtos.GymObject;

namespace Samson.Web.Application.ReadModels.Interfaces
{
    /// <summary>
    /// Read model to get gym object dtos
    /// </summary>
    public interface IGymObjectReadModel
    {
        /// <summary>
        /// Get gym object from collection by id
        /// </summary>
        /// <param name="id">key</param>
        /// <returns>dto</returns>
        Task<GymObjectDto> GetById(ObjectId id);

        /// <summary>
        /// Get all gym object from collection
        /// </summary>
        /// <returns>dtos list</returns>
        Task<List<GymObjectDto>> GetAll();

    }
}
