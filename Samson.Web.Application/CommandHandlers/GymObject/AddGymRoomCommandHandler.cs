using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MongoDB.Bson;
using Samson.Web.Application.Commands.GymObject;
using Samson.Web.Application.Infrastructure.Attributes;
using Samson.Web.Application.Models.DataStructures.GymObject;
using Samson.Web.Application.Services.Interfaces;

namespace Samson.Web.Application.CommandHandlers.GymObject
{
    /// <summary>
    /// RemoveGymRoomCommand command handler.
    /// </summary>
    [CommandHandler]
    public class AddGymRoomCommandHandler : IRequestHandler<AddGymRoomCommand, ObjectId>
    {
        private readonly IGymObjectService _service;
        private readonly IMapper _mapper;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="service">Service to manage GymObject domain</param>
        /// <param name="mapper">Mapper to map between models</param>
        public AddGymRoomCommandHandler(IGymObjectService service, IMapper mapper)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Handle AddGymRoomCommand command.
        /// </summary>
        /// <param name="request">Command</param>
        /// <param name="cancellationToken">Cancellation notification</param>
        /// <returns></returns>
        public Task<ObjectId> Handle(AddGymRoomCommand request, CancellationToken cancellationToken)
        {
            var dataStructure = _mapper.Map<AddGymRoomCommand, AddGymRoomDataStructure>(request);
            return _service.AddRoom(dataStructure);
        }
    }
}
