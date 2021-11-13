using System;
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
    /// Get ExerciseMachine by id query handler.
    /// </summary>
    [QueryHandler]
    public class GetExerciseMachineByIdQueryHandler : IRequestHandler<GetExerciseMachineByIdQuery, ExerciseMachineDto>
    {
        private readonly IExerciseMachineReadModel _readModel;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="readModel">Read model to read ExerciseMachine Dto by id from collection.</param>
        public GetExerciseMachineByIdQueryHandler(IExerciseMachineReadModel readModel)
        {
            _readModel = readModel ?? throw new ArgumentNullException(nameof(readModel));
        }

        /// <summary>
        /// Handle GetExerciseMachineByIdQuery query.
        /// </summary>
        /// <param name="request">Query</param>
        /// <param name="cancellationToken">Cancellation notification</param>
        /// <returns></returns>
        public Task<ExerciseMachineDto> Handle(GetExerciseMachineByIdQuery request, CancellationToken cancellationToken)
            => _readModel.GetById(request.Id);
    }
}