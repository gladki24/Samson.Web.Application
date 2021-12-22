using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MongoDB.Bson;
using Samson.Web.Application.Commands.GymPass;
using Samson.Web.Application.Infrastructure.Attributes;
using Samson.Web.Application.Models.DataStructures.GymPass;
using Samson.Web.Application.Services.Interfaces;

namespace Samson.Web.Application.CommandHandlers.GymPass
{
    /// <summary>
    /// CreateGymPassTypeCommand command handler.
    /// </summary>
    [CommandHandler]
    public class CreateGymPassTypeCommandHandler : IRequestHandler<CreateGymPassTypeCommand, ObjectId>
    {
        private readonly IGymPassTypeService _service;
        private readonly IMapper _mapper;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="service">Service to manage GymPassType domain</param>
        /// <param name="mapper">Mapper to map between models</param>
        public CreateGymPassTypeCommandHandler(IGymPassTypeService service, IMapper mapper)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Handle CreateGymPassTypeCommand command.
        /// </summary>
        /// <param name="request">Command</param>
        /// <param name="cancellationToken">Cancellation notification</param>
        /// <returns>Id of created gym pass</returns>
        public Task<ObjectId> Handle(CreateGymPassTypeCommand request, CancellationToken cancellationToken)
        {
            var dataStructure = _mapper.Map<CreateGymPassTypeCommand, CreateGymPassTypeDataStructure>(request);
            return _service.Create(dataStructure);
        }
    }
}
