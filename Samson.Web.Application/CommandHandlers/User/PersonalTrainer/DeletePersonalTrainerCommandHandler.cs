using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MongoDB.Bson;
using Samson.Web.Application.Commands.User.PersonalTrainer;
using Samson.Web.Application.Infrastructure.Attributes;
using Samson.Web.Application.Models.DataStructures.User;
using Samson.Web.Application.Services.Interfaces;

namespace Samson.Web.Application.CommandHandlers.User.PersonalTrainer
{
    /// <summary>
    /// DeletePersonalTrainerCommand command handler.
    /// </summary>
    [CommandHandler]
    public class DeletePersonalTrainerCommandHandler : IRequestHandler<DeletePersonalTrainerCommand, ObjectId>
    {
        private readonly IPersonalTrainerService _service;
        private readonly IMapper _mapper;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="service">Service to manage PersonalTrainer domain</param>
        /// <param name="mapper">Mapper to map between models</param>
        public DeletePersonalTrainerCommandHandler(IPersonalTrainerService service, IMapper mapper)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Handle DeletePersonalTrainerCommand command.
        /// </summary>
        /// <param name="request">Command</param>
        /// <param name="cancellationToken">Cancellation notification</param>
        public Task<ObjectId> Handle(DeletePersonalTrainerCommand request, CancellationToken cancellationToken)
        {
            var dataStructure = _mapper.Map<DeletePersonalTrainerCommand, DeleteUserDataStructure>(request);
            return _service.Delete(dataStructure);
        }
    }
}
