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
    /// UpdateEventCommand command handler.
    /// </summary>
    [CommandHandler]
    public class UpdatePersonalTrainerCommandHandler : IRequestHandler<UpdatePersonalTrainerCommand, ObjectId>
    {
        private readonly IPersonalTrainerService _service;
        private readonly IMapper _mapper;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="service">Service to manage User domain</param>
        /// <param name="mapper">Mapper to map between models</param>
        public UpdatePersonalTrainerCommandHandler(IPersonalTrainerService service, IMapper mapper)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Handle UpdatePersonalTrainerCommand command.
        /// </summary>
        /// <param name="request">Command</param>
        /// <param name="cancellationToken">Cancellation notification</param>
        /// <returns>Updated User Id</returns>
        public Task<ObjectId> Handle(UpdatePersonalTrainerCommand request, CancellationToken cancellationToken)
        {
            var dataStructure = _mapper.Map<UpdatePersonalTrainerCommand, UpdatePersonalTrainerDataStructure>(request);
            return _service.Update(dataStructure);
        }
    }
}
