using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MongoDB.Bson;
using Samson.Web.Application.Commands.User;
using Samson.Web.Application.Commands.User.PersonalTrainer;
using Samson.Web.Application.Infrastructure.Attributes;
using Samson.Web.Application.Models.DataStructures.User.PersonalTrainer;
using Samson.Web.Application.Services.Interfaces;

namespace Samson.Web.Application.CommandHandlers.User.PersonalTrainer
{
    /// <summary>
    /// CreatePersonalTrainerCommand command handler.
    /// </summary>
    [CommandHandler]
    public class CreatePersonalTrainerCommandHandler : IRequestHandler<CreatePersonalTrainerCommand, ObjectId>
    {
        private readonly IPersonalTrainerService _service;
        private readonly IMapper _mapper;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="service">Service to manage PersonalTrainer domain</param>
        /// <param name="mapper">Mapper to map between models</param>
        public CreatePersonalTrainerCommandHandler(IPersonalTrainerService service, IMapper mapper)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Handle CreatePersonalTrainerCommand command.
        /// </summary>
        /// <param name="request">Command</param>
        /// <param name="cancellationToken">Cancellation notification</param>
        /// <returns>Id of created personal trainer account</returns>
        public Task<ObjectId> Handle(CreatePersonalTrainerCommand request, CancellationToken cancellationToken)
        {
            var dataStructure = _mapper.Map<CreatePersonalTrainerCommand, CreatePersonalTrainerDataStructure>(request);
            return _service.Create(dataStructure);
        }
    }
}
