using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MongoDB.Bson;
using Samson.Web.Application.Commands.User.Client;
using Samson.Web.Application.Infrastructure.Attributes;
using Samson.Web.Application.Models.DataStructures.User.Client;
using Samson.Web.Application.Services.Interfaces;

namespace Samson.Web.Application.CommandHandlers.User.Client
{
    /// <summary>
    /// RegisterClientCommand command handler.
    /// </summary>
    [CommandHandler]
    public class RegisterClientCommandHandler : IRequestHandler<RegisterClientCommand, ObjectId>
    {
        private readonly IClientService _service;
        private readonly IMapper _mapper;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="service">Service to manage Client</param>
        /// <param name="mapper">Mapper to map between models</param>
        public RegisterClientCommandHandler(IClientService service, IMapper mapper)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Handle RegisterUserCommand command.
        /// </summary>
        /// <param name="request">Command</param>
        /// <param name="cancellationToken">Cancellation notification</param>
        /// <returns>Id of registered client</returns>
        public Task<ObjectId> Handle(RegisterClientCommand request, CancellationToken cancellationToken)
        {
            var dataStructure = _mapper.Map<RegisterClientCommand, RegisterClientDataStructure>(request);
            return _service.Register(dataStructure);
        }
    }
}
