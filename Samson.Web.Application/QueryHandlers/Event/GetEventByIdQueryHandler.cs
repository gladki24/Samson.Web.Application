using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Samson.Web.Application.Infrastructure.Attributes;
using Samson.Web.Application.Models.Dtos.Event;
using Samson.Web.Application.Queries.Event;
using Samson.Web.Application.ReadModels.Interfaces;

namespace Samson.Web.Application.QueryHandlers.Event
{
    /// <summary>
    /// Get Event by id query handler
    /// </summary>
    [QueryHandler]
    public class GetEventByIdQueryHandler : IRequestHandler<GetEventByIdQuery, EventDto>
    {
        private readonly IEventReadModel _readModel;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="readModel">Read model to read EventDto by id from collection.</param>
        public GetEventByIdQueryHandler(IEventReadModel readModel)
        {
            _readModel = readModel ?? throw new ArgumentNullException(nameof(readModel));
        }

        /// <summary>
        /// Handle GetEventByIdQuery query.
        /// </summary>
        /// <param name="request">Query</param>
        /// <param name="cancellationToken">Cancellation notification</param>
        /// <returns>DTO</returns>
        public Task<EventDto> Handle(GetEventByIdQuery request, CancellationToken cancellationToken)
        {
            return _readModel.GetById(request.Id);
        }
    }
}
