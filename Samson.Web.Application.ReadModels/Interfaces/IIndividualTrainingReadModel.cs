using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using Samson.Web.Application.Models.Dtos.IndividualTraining;

namespace Samson.Web.Application.ReadModels.Interfaces
{
    /// <summary>
    /// Read model to get IndividualTraining dtos.
    /// </summary>
    public interface IIndividualTrainingReadModel
    {
        /// <summary>
        /// Get IndividualTraining from collection by id.
        /// </summary>
        /// <param name="id">Key</param>
        /// <returns>Dto</returns>
        Task<IndividualTrainingDto> GetById(ObjectId id);

        /// <summary>
        /// Get all IndividualTraining dtos from collection.
        /// </summary>
        /// <returns>Dtos list</returns>
        Task<List<IndividualTrainingDto>> GetAll();
    }
}