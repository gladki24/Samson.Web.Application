using System.Threading.Tasks;
using MongoDB.Bson;
using Samson.Web.Application.Models.DataStructures.IndividualTraining;

namespace Samson.Web.Application.Services.Interfaces
{
    /// <summary>
    /// Services to work with IndividualTraining model.
    /// </summary>
    public interface IIndividualTrainingService
    {
        /// <summary>
        /// Create IndividualTraining aggregate.
        /// </summary>
        /// <param name="dataStructure">Data to create new IndividualTraining</param>
        /// <returns>Created IndividualTraining Id</returns>
        Task<ObjectId> Create(CreateIndividualTrainingDataStructure dataStructure);

        /// <summary>
        /// Update IndividualTraining aggregate.
        /// </summary>
        /// <param name="dataStructure">Data to update IndividualTraining</param>
        /// <returns>Updated IndividualTraining Id</returns>
        Task<ObjectId> Update(UpdateIndividualTrainingDataStructure dataStructure);

        /// <summary>
        /// Cancel IndividualTraining aggregate.
        /// </summary>
        /// <param name="dataStructure">Data to cancel IndividualTraining</param>
        /// <returns>Cancelled IndividualTraining Id</returns>
        Task<ObjectId> Cancel(CancelIndividualTrainingDataStructure dataStructure);

        /// <summary>
        /// Confirm pending IndividualTraining.
        /// </summary>
        /// <param name="dataStructure">Data to confirm pending IndividualTraining</param>
        /// <returns>Confirmed IndividualTraining Id</returns>
        Task<ObjectId> Confirm(ConfirmIndividualTrainingDataStructure dataStructure);

        /// <summary>
        /// Enroll Client in IndividualTraining.
        /// </summary>
        /// <param name="dataStructure">Data to enroll client in IndividualTraining</param>
        /// <returns>IndividualTraining</returns>
        Task<ObjectId> Enroll(EnrollInIndividualTrainingDataStructure dataStructure);
    }
}
