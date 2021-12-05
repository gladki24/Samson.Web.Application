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
    /// UpdateClientCommand command handler.
    /// </summary>
    [CommandHandler]
    public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand, ObjectId>
    {
        private readonly IClientService _service;
        private readonly IMapper _mapper;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="service">Service to manage Client</param>
        /// <param name="mapper">Mapper to map between models</param>
        public UpdateClientCommandHandler(IClientService service, IMapper mapper)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Handle UpdateClientCommand command.
        /// </summary>
        /// <param name="request">Command</param>
        /// <param name="cancellationToken">Cancellation notification</param>
        /// <returns>Id of updated client account</returns>
        public Task<ObjectId> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {
            var dataStructure = _mapper.Map<UpdateClientCommand, UpdateClientDataStructure>(request);
            return _service.Update(dataStructure);
        }
    }
}
