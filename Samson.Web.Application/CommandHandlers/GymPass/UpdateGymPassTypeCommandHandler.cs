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
    /// UpdateGymPassType command handler.
    /// </summary>
    [CommandHandler]
    public class UpdateGymPassTypeCommandHandler : IRequestHandler<UpdateGymPassTypeCommand, ObjectId>
    {
        private readonly IGymPassTypeService _service;
        private readonly IMapper _mapper;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="service">Service to manage GymPassType</param>
        /// <param name="mapper">Mapper to map between models</param>
        public UpdateGymPassTypeCommandHandler(IGymPassTypeService service, IMapper mapper)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Handle UpdateGymPassTypeCommand command.
        /// </summary>
        /// <param name="request">Command</param>
        /// <param name="cancellationToken">Cancellation notification</param>
        /// <returns>Id of updated gym pass</returns>
        public Task<ObjectId> Handle(UpdateGymPassTypeCommand request, CancellationToken cancellationToken)
        {
            var dataStructure = _mapper.Map<UpdateGymPassTypeCommand, UpdateGymPassTypeDataStructure>(request);
            return _service.Update(dataStructure);
        }
    }
}
