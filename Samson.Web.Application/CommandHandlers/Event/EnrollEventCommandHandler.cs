using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Samson.Web.Application.Commands.Event;
using Samson.Web.Application.Infrastructure.Attributes;
using Samson.Web.Application.Models.DataStructures.Event;
using Samson.Web.Application.Services.Interfaces;

namespace Samson.Web.Application.CommandHandlers.Event
{
    /// <summary>
    /// EnrollEventCommand command handler.
    /// </summary>
    [CommandHandler]
    public class EnrollEventCommandHandler : IRequestHandler<EnrollEventCommand, Unit>
    {
        private readonly IEventService _service;
        private readonly IMapper _mapper;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="service">Service to manage Event domain</param>
        /// <param name="mapper">Mapper to map between models</param>
        public EnrollEventCommandHandler(IEventService service, IMapper mapper)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Handle EnrollEventCommand command.
        /// </summary>
        /// <param name="request">Command</param>
        /// <param name="cancellationToken">Cancellation notification</param>
        public Task<Unit> Handle(EnrollEventCommand request, CancellationToken cancellationToken)
        {
            var dataStructure = _mapper.Map<EnrollEventCommand, EnrollEventDataStructure>(request);
            return _service.ClientEnroll(dataStructure);
        }
    }
}
