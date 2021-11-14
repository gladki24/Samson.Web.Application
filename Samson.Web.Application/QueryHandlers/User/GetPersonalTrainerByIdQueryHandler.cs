using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Samson.Web.Application.Infrastructure.Attributes;
using Samson.Web.Application.Models.Dtos.User;
using Samson.Web.Application.Queries.User;
using Samson.Web.Application.ReadModels.Interfaces;

namespace Samson.Web.Application.QueryHandlers.User
{
    /// <summary>
    /// Get PersonalTrainer by id query handler.
    /// </summary>
    [QueryHandler]
    public class GetPersonalTrainerByIdQueryHandler : IRequestHandler<GetPersonalTrainerByIdQuery, PersonalTrainerDto>
    {
        private readonly IPersonalTrainerReadModel _readModel;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="readModel">Read model to get PersonalTrainer by id</param>
        public GetPersonalTrainerByIdQueryHandler(IPersonalTrainerReadModel readModel)
        {
            _readModel = readModel ?? throw new ArgumentNullException(nameof(readModel));
        }

        /// <summary>
        /// Handle GetPersonalTrainerByIdQuery query.
        /// </summary>
        /// <param name="request">Query</param>
        /// <param name="cancellationToken">Cancellation notification</param>
        public Task<PersonalTrainerDto> Handle(GetPersonalTrainerByIdQuery request, CancellationToken cancellationToken)
            => _readModel.GetById(request.Id);
    }
}
