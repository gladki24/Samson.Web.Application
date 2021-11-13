using Samson.Web.Application.Models.DataStructures.ExerciseMachine;
using Samson.Web.Application.Models.Domains;

namespace Samson.Web.Application.Factories.Interfaces
{
    /// <summary>
    /// Factory to create ExerciseMachine domain.
    /// </summary>
    public interface IExerciseMachineFactory
    {
        /// <summary>
        /// Create ExerciseMachine data structure.
        /// </summary>
        /// <param name="dataStructure">Data structure to create ExerciseMachine</param>
        /// <returns>ExerciseMachine domain</returns>
        ExerciseMachine Create(CreateExerciseMachineDataStructure dataStructure);
    }
}
