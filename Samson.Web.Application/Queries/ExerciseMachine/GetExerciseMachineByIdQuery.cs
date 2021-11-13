using MediatR;
using MongoDB.Bson;
using Samson.Web.Application.Models.Dtos.ExerciseMachine;

namespace Samson.Web.Application.Queries.ExerciseMachine
{
    /// <summary>
    /// Query to get ExerciseMachine by id.
    /// </summary>
    public class GetExerciseMachineByIdQuery : IRequest<ExerciseMachineDto>
    {
        public ObjectId Id { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="id">Key</param>
        public GetExerciseMachineByIdQuery(ObjectId id)
        {
            Id = id;
        }
    }
}
