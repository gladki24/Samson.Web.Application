using System;
using System.Collections.Generic;
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
    /// Get all Events query handler.
    /// </summary>
    [QueryHandler]
    public class GetAllEventsQueryHandler : IRequestHandler<GetAllEventsQuery, List<EventDto>>
    {
        private readonly IEventReadModel _readModel;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="readModel">Read model to read Event dtos from collection.</param>
        public GetAllEventsQueryHandler(IEventReadModel readModel)
        {
            _readModel = readModel ?? throw new ArgumentNullException(nameof(readModel));
        }

        /// <summary>
        /// Handle AllEventsQuery.
        /// </summary>
        /// <param name="request">Command</param>
        /// <param name="cancellationToken">Cancellation notification</param>
        /// <returns></returns>
        public Task<List<EventDto>> Handle(GetAllEventsQuery request, CancellationToken cancellationToken)
        {
            return _readModel.GetAll();
        }
    }
}