using System.Threading.Tasks;
using MongoDB.Bson;
using Samson.Web.Application.Models.DataStructures.User.PersonalTrainer;

namespace Samson.Web.Application.Services.Interfaces
{
    public interface IPersonalTrainerService : IUserService
    {
        /// <summary>
        /// CreatePersonalTrainer User aggregate.
        /// </summary>
        /// <param name="dataStructure">Data to create User domain</param>
        /// <returns>Created User Id</returns>
        Task<ObjectId> Create(CreatePersonalTrainerDataStructure dataStructure);

        /// <summary>
        /// Update PersonalTrainer aggregate.
        /// </summary>
        /// <param name="dataStructure">Data to update PersonalTrainer domain</param>
        /// <returns>Updated PersonalTrainer Id</returns>
        Task<ObjectId> Update(UpdatePersonalTrainerDataStructure dataStructure);
    }
}
