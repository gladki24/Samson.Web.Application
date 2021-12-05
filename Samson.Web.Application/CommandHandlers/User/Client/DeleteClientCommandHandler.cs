using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MongoDB.Bson;
using Samson.Web.Application.Commands.User.Client;
using Samson.Web.Application.Infrastructure.Attributes;
using Samson.Web.Application.Models.DataStructures.User;
using Samson.Web.Application.Services.Interfaces;

namespace Samson.Web.Application.CommandHandlers.User.Client
{
    /// <summary>
    /// DeleteClientCommand command handler.
    /// </summary>
    [CommandHandler]
    public class DeleteClientCommandHandler : IRequestHandler<DeleteClientCommand, ObjectId>
    {
        private readonly IClientService _service;
        private readonly IMapper _mapper;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="service">Service to manage Client domain</param>
        /// <param name="mapper">Mapper to map between models</param>
        public DeleteClientCommandHandler(IClientService service, IMapper mapper)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Handle DeleteClientCommand command.
        /// </summary>
        /// <param name="request">Command</param>
        /// <param name="cancellationToken">Cancellation notification</param>
        /// <returns>Id of deleted client account</returns>
        public Task<ObjectId> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
        {
            var dataStructure = _mapper.Map<DeleteClientCommand, DeleteUserDataStructure>(request);
            return _service.Delete(dataStructure);
        }
    }
}
