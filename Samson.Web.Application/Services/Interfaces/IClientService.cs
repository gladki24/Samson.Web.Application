using System.Threading.Tasks;
using MediatR;
using MongoDB.Bson;
using Samson.Web.Application.Models.DataStructures.User.Client;

namespace Samson.Web.Application.Services.Interfaces
{
    /// <summary>
    /// Application service to work with Client.
    /// </summary>
    public interface IClientService : IUserService
    {
        /// <summary>
        /// Register new Client.
        /// </summary>
        /// <param name="dataStructure">Data to register new Client</param>
        /// <returns>CreatePersonalTrainer Client Id</returns>
        Task<ObjectId> Register(RegisterClientDataStructure dataStructure);

        /// <summary>
        /// Update Client aggregate.
        /// </summary>
        /// <param name="dataStructure">Data to update Client domain</param>
        /// <returns>Updated Client Id</returns>
        Task<ObjectId> Update(UpdateClientDataStructure dataStructure);

        /// <summary>
        /// Extend Client gym pass.
        /// </summary>
        /// <param name="dataStructure">Data structure to extend gym pass.</param>
        Task<Unit> ExtendGymPass(ExtendClientPassDataStructure dataStructure);
    }
}
