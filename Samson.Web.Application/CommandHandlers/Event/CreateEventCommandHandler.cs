using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MongoDB.Bson;
using Samson.Web.Application.Commands.Event;
using Samson.Web.Application.Infrastructure.Attributes;
using Samson.Web.Application.Models.DataStructures.Event;
using Samson.Web.Application.Services.Interfaces;

namespace Samson.Web.Application.CommandHandlers.Event
{
    /// <summary>
    /// CreateEventCommand command handler
    /// </summary>
    [CommandHandler]
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, ObjectId>
    {
        private readonly IEventService _service;
        private readonly IMapper _mapper;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="service">Service to manage Event domain</param>
        /// <param name="mapper">Mapper to map between models</param>
        public CreateEventCommandHandler(IEventService service, IMapper mapper)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Handle CreateEventCommand command
        /// </summary>
        /// <param name="request">command</param>
        /// <param name="cancellationToken">cancellation notification</param>
        /// <returns></returns>
        Task<ObjectId> IRequestHandler<CreateEventCommand, ObjectId>.Handle(CreateEventCommand request,
            CancellationToken cancellationToken)
        {
            var dataStructure = _mapper.Map<CreateEventCommand, CreateEventDataStructure>(request);
            return _service.Create(dataStructure);
        }
    }
}
