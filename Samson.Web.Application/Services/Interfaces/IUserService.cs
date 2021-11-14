using System.Threading.Tasks;
using MongoDB.Bson;
using Samson.Web.Application.Models.DataStructures.User;

namespace Samson.Web.Application.Services.Interfaces
{
    /// <summary>
    /// Services to work with User domain.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Delete User domain.
        /// </summary>
        /// <param name="dataStructure">Data to delete User domain</param>
        /// <returns>Deleted User Id</returns>
        Task<ObjectId> Delete(DeleteUserDataStructure dataStructure);
    }
}
