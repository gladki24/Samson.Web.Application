using System.Threading.Tasks;
using MongoDB.Bson;
using Samson.Web.Application.Models.DataStructures.User.Client;

namespace Samson.Web.Application.Services.Interfaces
{
    public interface IClientService : IUserService
    {
        /// <summary>
        /// Register new Client.
        /// </summary>
        /// <param name="dataStructure">Data to register new Client</param>
        /// <returns>CreatePersonalTrainer Client Id</returns>
        Task<ObjectId> Register(RegisterClientDataStructure dataStructure);

        /// <summary>
        /// Update Client domain.
        /// </summary>
        /// <param name="dataStructure">Data to update Client domain</param>
        /// <returns>Updated Client Id</returns>
        Task<ObjectId> Update(UpdateClientDataStructure dataStructure);
    }
}
