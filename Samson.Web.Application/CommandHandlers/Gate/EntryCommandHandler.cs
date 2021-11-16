using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MongoDB.Bson;
using Samson.Web.Application.Commands.Gate;
using Samson.Web.Application.Infrastructure.Attributes;
using Samson.Web.Application.Models.DataStructures.Gym;
using Samson.Web.Application.Services.Interfaces;

namespace Samson.Web.Application.CommandHandlers.Gate
{
    /// <summary>
    /// EntryCommand command handler.
    /// </summary>
    [CommandHandler]
    public class EntryCommandHandler : IRequestHandler<EntryCommand, ObjectId>
    {
        private readonly IGateService _service;
        private readonly IMapper _mapper;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="service">Service to manage entrance and exit from gym</param>
        /// <param name="mapper">Mapper to map between models</param>
        public EntryCommandHandler(IGateService service, IMapper mapper)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Handle EntryCommand command.
        /// </summary>
        /// <param name="request">Command</param>
        /// <param name="cancellationToken">Cancellation notification</param>
        /// <returns>Entrance Id</returns>
        public Task<ObjectId> Handle(EntryCommand request, CancellationToken cancellationToken)
        {
            var dataStructure = _mapper.Map<EntryCommand, EntryDataStructure>(request);
            return _service.Entry(dataStructure);
        }
    }
}
