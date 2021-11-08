using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        /// Create User domain.
        /// </summary>
        /// <param name="dataStructure">Data to create User domain</param>
        /// <returns>Created User Id</returns>
        Task<ObjectId> Create(CreateUserDataStructure dataStructure);

        /// <summary>
        /// Update User domain.
        /// </summary>
        /// <param name="dataStructure">Data to update User domain</param>
        /// <returns>Updated User Id</returns>
        Task<ObjectId> Update(UpdateUserDataStructure dataStructure);

        /// <summary>
        /// Delete User domain.
        /// </summary>
        /// <param name="dataStructure">Data to delete User domain</param>
        /// <returns>Deleted User Id</returns>
        Task<ObjectId> Delete(DeleteUserDataStructure dataStructure);

        /// <summary>
        /// Authenticate User.
        /// </summary>
        /// <returns>JWT Token</returns>
        Task<string> Authenticate(AuthenticateUserDataStructure dataStructure);
    }
}
