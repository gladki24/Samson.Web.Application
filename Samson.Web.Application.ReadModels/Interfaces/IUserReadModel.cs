using System.Threading.Tasks;
using MongoDB.Bson;
using Samson.Web.Application.Models.Dtos.User;

namespace Samson.Web.Application.ReadModels.Interfaces
{
    /// <summary>
    /// Read model to get User dto.
    /// </summary>
    public interface IUserReadModel
    {
        /// <summary>
        /// Get User from collection by id.
        /// </summary>
        /// <param name="id">Key</param>
        /// <returns>Dto</returns>
        Task<UserDto> GetById(ObjectId id);
    }
}
