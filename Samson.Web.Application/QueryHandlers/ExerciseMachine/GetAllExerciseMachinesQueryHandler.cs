using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Samson.Web.Application.Infrastructure.Attributes;
using Samson.Web.Application.Models.Dtos.ExerciseMachine;
using Samson.Web.Application.Queries.ExerciseMachine;
using Samson.Web.Application.ReadModels.Interfaces;

namespace Samson.Web.Application.QueryHandlers.ExerciseMachine
{
    /// <summary>
    /// Get all ExerciseMachine query handler.
    /// </summary>
    [QueryHandler]
    public class GetAllExerciseMachinesQueryHandler : IRequestHandler<GetAllExerciseMachinesQuery, List<ExerciseMachineDto>>
    {
        private readonly IExerciseMachineReadModel _readModel;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="readModel">Read model to read ExerciseMachine dtos from collection.</param>
        public GetAllExerciseMachinesQueryHandler(IExerciseMachineReadModel readModel)
        {
            _readModel = readModel ?? throw new ArgumentNullException(nameof(readModel));
        }

        /// <summary>
        /// Handle ExerciseMachineQuery.
        /// </summary>
        /// <param name="request">Command</param>
        /// <param name="cancellationToken">Cancellation notification</param>
        /// <returns></returns>
        public Task<List<ExerciseMachineDto>> Handle(GetAllExerciseMachinesQuery request, CancellationToken cancellationToken)
            => _readModel.GetAll();
    }
}
