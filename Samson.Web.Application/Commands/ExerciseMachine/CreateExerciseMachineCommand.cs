using MediatR;
using MongoDB.Bson;

namespace Samson.Web.Application.Commands.ExerciseMachine
{
    /// <summary>
    /// Command to create ExerciseMachine.
    /// </summary>
    public class CreateExerciseMachineCommand : IRequest<ObjectId>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public string LocalizationGymObjectId { get; set; }
    }
}
