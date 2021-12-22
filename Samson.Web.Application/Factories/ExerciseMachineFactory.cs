using MongoDB.Bson;
using Samson.Web.Application.Factories.Interfaces;
using Samson.Web.Application.Infrastructure.Attributes;
using Samson.Web.Application.Models.DataStructures.ExerciseMachine;
using Samson.Web.Application.Models.Domains;

namespace Samson.Web.Application.Factories
{
    /// <summary>
    /// Factory to create ExerciseMachine model
    /// </summary>
    [Factory]
    public class ExerciseMachineFactory : IExerciseMachineFactory
    {
        /// <summary>
        /// Create ExerciseMachine model with id generation
        /// </summary>
        /// <param name="dataStructure">Information about machine</param>
        /// <returns>ExerciseMachine</returns>
        public ExerciseMachine Create(CreateExerciseMachineDataStructure dataStructure)
            => new ExerciseMachine(ObjectId.GenerateNewId(), dataStructure);
    }
}
