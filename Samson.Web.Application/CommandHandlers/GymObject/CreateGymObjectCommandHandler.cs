using System;
using MediatR;
using Samson.Web.Application.Commands.GymObject;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MongoDB.Bson;
using Samson.Web.Application.Infrastructure.Attributes;
using Samson.Web.Application.Models.DataStructures;
using Samson.Web.Application.Models.DataStructures.GymObject;
using Samson.Web.Application.Services.Interfaces;

namespace Samson.Web.Application.CommandHandlers.GymObject
{
    /// <summary>
    /// CreateGymObjectCommand command handler
    /// </summary>
    [CommandHandler]
    public class CreateGymObjectCommandHandler : IRequestHandler<CreateGymObjectCommand, ObjectId>
    {
        private readonly IGymObjectService _service;
        private readonly IMapper _mapper;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="service">Service to manage GymObject domain</param>
        /// <param name="mapper">Mapper to map between models</param>
        public CreateGymObjectCommandHandler(IGymObjectService service, IMapper mapper)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Handle CreateGymObjectCommand command
        /// </summary>
        /// <param name="request">command</param>
        /// <param name="cancellationToken">cancellation notification</param>
        /// <returns>void</returns>
        Task<ObjectId> IRequestHandler<CreateGymObjectCommand, ObjectId>.Handle(CreateGymObjectCommand request, CancellationToken cancellationToken)
        {
            var dataStructure = _mapper.Map<CreateGymObjectCommand, CreateGymObjectDataStructure>(request);
            return _service.Create(dataStructure);
        }
    }
}
