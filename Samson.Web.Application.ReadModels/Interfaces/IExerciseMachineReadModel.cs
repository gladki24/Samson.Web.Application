
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using Samson.Web.Application.Models.Dtos.ExerciseMachine;

namespace Samson.Web.Application.ReadModels.Interfaces
{
    /// <summary>
    /// Read model to get ExerciseMachine dtos.
    /// </summary>
    public interface IExerciseMachineReadModel
    {
        /// <summary>
        /// Get ExerciseMachine from collection by id.
        /// </summary>
        /// <param name="id">Key</param>
        /// <returns>Dto</returns>
        Task<ExerciseMachineDto> GetById(ObjectId id);

        /// <summary>
        /// Get all ExerciseMachine dtos from collection.
        /// </summary>
        /// <returns>Dtos list</returns>
        Task<List<ExerciseMachineDto>> GetAll();
    }
}
