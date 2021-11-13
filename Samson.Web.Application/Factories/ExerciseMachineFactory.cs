using MongoDB.Bson;
using Samson.Web.Application.Factories.Interfaces;
using Samson.Web.Application.Infrastructure.Attributes;
using Samson.Web.Application.Models.DataStructures.ExerciseMachine;
using Samson.Web.Application.Models.Domains;

namespace Samson.Web.Application.Factories
{
    [Factory]
    public class ExerciseMachineFactory : IExerciseMachineFactory
    {
        public ExerciseMachine Create(CreateExerciseMachineDataStructure dataStructure)
            => new ExerciseMachine(ObjectId.GenerateNewId(), dataStructure);
    }
}
