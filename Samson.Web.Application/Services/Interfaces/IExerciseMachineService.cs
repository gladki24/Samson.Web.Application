using System.Threading.Tasks;
using MongoDB.Bson;
using Samson.Web.Application.Models.DataStructures.ExerciseMachine;

namespace Samson.Web.Application.Services.Interfaces
{
    /// <summary>
    /// Services to work with ExerciseMachine domain.
    /// </summary>
    public interface IExerciseMachineService
    {
        /// <summary>
        /// Create ExerciseMachine domain.
        /// </summary>
        /// <param name="dataStructure">Data to create ExerciseMachine domain</param>
        /// <returns>ExerciseMachine Id</returns>
        Task<ObjectId> Create(CreateExerciseMachineDataStructure dataStructure);

        /// <summary>
        /// Update ExerciseMachine domain.
        /// </summary>
        /// <param name="dataStructure">Data to update ExerciseMachine domain</param>
        /// <returns>ExerciseMachine Id</returns>
        Task<ObjectId> Update(UpdateExerciseMachineDataStructure dataStructure);

        /// <summary>
        /// Delete ExerciseMachineDomain.
        /// </summary>
        /// <param name="id">Id of ExerciseMachine</param>
        /// <returns>ExerciseMachine Id</returns>
        Task<ObjectId> Delete(ObjectId id);
    }
}
