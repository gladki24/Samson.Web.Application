using MediatR;
using MongoDB.Bson;

namespace Samson.Web.Application.Commands.ExerciseMachine
{
    /// <summary>
    /// Command to update ExerciseMachine.
    /// </summary>
    public class UpdateExerciseMachineCommand : IRequest<ObjectId>
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public string LocalizationGymObjectId { get; set; }
    }
}
