using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MongoDB.Bson;
using Samson.Web.Application.Commands.Event;
using Samson.Web.Application.Infrastructure.Attributes;
using Samson.Web.Application.Services.Interfaces;

namespace Samson.Web.Application.CommandHandlers.Event
{
    /// <summary>
    /// DeleteEventCommand command handler
    /// </summary>
    [CommandHandler]
    public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand, ObjectId>
    {
        private readonly IEventService _service;
        private readonly IMapper _mapper;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="service">Service to manage Event domain</param>
        /// <param name="mapper">Mapper to map between models</param>
        public DeleteEventCommandHandler(IEventService service, IMapper mapper)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Handle DeleteEventCommand command.
        /// </summary>
        /// <param name="request">Command</param>
        /// <param name="cancellationToken">Cancellation notification</param>
        /// <returns>Deleted event Id</returns>
        public Task<ObjectId> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            var id = _mapper.Map<string, ObjectId>(request.Id);
            return _service.Delete(id);
        }
    }
}
