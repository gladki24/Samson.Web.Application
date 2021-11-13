using MediatR;
using MongoDB.Bson;

namespace Samson.Web.Application.Commands.ExerciseMachine
{
    /// <summary>
    /// Command to delete ExerciseMachine.
    /// </summary>
    public class DeleteExerciseMachineCommand : IRequest<ObjectId>
    {
        public string Id { get; set; }
    }
}
