using System.Threading.Tasks;
using MongoDB.Bson;
using Samson.Web.Application.Models.Dtos.User;

namespace Samson.Web.Application.ReadModels.Interfaces
{
    /// <summary>
    /// Read model to get Client dto.
    /// </summary>
    public interface IClientReadModel
    {
        /// <summary>
        /// Get Client from collection by id.
        /// </summary>
        /// <param name="id">Key</param>
        /// <returns>Dto</returns>
        Task<ClientDto> GetById(ObjectId id);
    }
}
