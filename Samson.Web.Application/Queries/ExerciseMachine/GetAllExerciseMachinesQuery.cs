using System.Collections.Generic;
using MediatR;
using Samson.Web.Application.Models.Dtos.ExerciseMachine;

namespace Samson.Web.Application.Queries.ExerciseMachine
{
    /// <summary>
    /// Query to get all ExerciseMachine dtos.
    /// </summary>
    public class GetAllExerciseMachinesQuery : IRequest<List<ExerciseMachineDto>>
    {
    }
}
