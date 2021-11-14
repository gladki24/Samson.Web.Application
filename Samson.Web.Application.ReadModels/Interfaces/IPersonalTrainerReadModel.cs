using System.Threading.Tasks;
using MongoDB.Bson;
using Samson.Web.Application.Models.Dtos.User;

namespace Samson.Web.Application.ReadModels.Interfaces
{
    /// <summary>
    /// Read model to get PersonalTrainer dto.
    /// </summary>
    public interface IPersonalTrainerReadModel
    {
        /// <summary>
        /// Get PersonalTrainer from collection by id.
        /// </summary>
        /// <param name="id">Key</param>
        /// <returns>Dto</returns>
        Task<PersonalTrainerDto> GetById(ObjectId id);
    }
}
