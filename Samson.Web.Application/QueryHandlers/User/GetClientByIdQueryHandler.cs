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
    /// Get Client by id query handler.
    /// </summary>
    [QueryHandler]
    public class GetClientByIdQueryHandler : IRequestHandler<GetClientByIdQuery, ClientDto>
    {
        private readonly IClientReadModel _readModel;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="readModel">Read model to get Client by id</param>
        public GetClientByIdQueryHandler(IClientReadModel readModel)
        {
            _readModel = readModel ?? throw new ArgumentNullException(nameof(readModel));
        }

        /// <summary>
        /// Handle GetClientByIdQuery query.
        /// </summary>
        /// <param name="request">Query</param>
        /// <param name="cancellationToken">Cancellation notification</param>
        public Task<ClientDto> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
            => _readModel.GetById(request.Id);
    }
}
