using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Samson.Web.Application.Commands.User.Client;
using Samson.Web.Application.Infrastructure.Attributes;
using Samson.Web.Application.Models.DataStructures.User.Client;
using Samson.Web.Application.Services.Interfaces;

namespace Samson.Web.Application.CommandHandlers.User.Client
{
    /// <summary>
    /// ExtendClientPassCommand command handler.
    /// </summary>
    [CommandHandler]
    public class ExtendClientPassCommandHandler : IRequestHandler<ExtendClientPassCommand, Unit>
    {
        private readonly IClientService _service;
        private readonly IMapper _mapper;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="service">Service to manage Client account</param>
        /// <param name="mapper">Mapper to map between models</param>
        public ExtendClientPassCommandHandler(IClientService service, IMapper mapper)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Handle ExtendClientPassCommand command.
        /// </summary>
        /// <param name="request">Command</param>
        /// <param name="cancellationToken">Cancellation notification</param>
        /// <returns>Id of client</returns>
        public Task<Unit> Handle(ExtendClientPassCommand request, CancellationToken cancellationToken)
        {
            var dataStructure = _mapper.Map<ExtendClientPassCommand, ExtendClientPassDataStructure>(request);
            return _service.ExtendGymPass(dataStructure);
        }
    }
}
