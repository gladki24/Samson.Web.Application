using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Samson.Web.Application.Commands.Gate;
using Samson.Web.Application.Infrastructure.Attributes;
using Samson.Web.Application.Models.DataStructures.Gym;
using Samson.Web.Application.Services.Interfaces;

namespace Samson.Web.Application.CommandHandlers.Gate
{
    /// <summary>
    /// ExitCommand command handler.
    /// </summary>
    [CommandHandler]
    public class ExitCommandHandler : IRequestHandler<ExitCommand>
    {
        private readonly IGateService _service;
        private readonly IMapper _mapper;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="service">Service to manage entrance and exit from gym</param>
        /// <param name="mapper">Mapper to map between models</param>
        public ExitCommandHandler(IGateService service, IMapper mapper)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Handle ExitCommand command.
        /// </summary>
        /// <param name="request">Command</param>
        /// <param name="cancellationToken">Cancellation notification</param>
        public Task<Unit> Handle(ExitCommand request, CancellationToken cancellationToken)
        {
            var dataStructure = _mapper.Map<ExitCommand, ExitDataStructure>(request);
            return _service.Exit(dataStructure);
        }
    }
}
