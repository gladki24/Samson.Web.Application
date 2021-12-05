using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MongoDB.Bson;
using Samson.Web.Application.Commands.GymPass;
using Samson.Web.Application.Infrastructure.Attributes;
using Samson.Web.Application.Services.Interfaces;

namespace Samson.Web.Application.CommandHandlers.GymPass
{
    /// <summary>
    /// DeleteGymPassType command handler.
    /// </summary>
    [CommandHandler]
    public class DeleteGymPassTypeCommandHandler : IRequestHandler<DeleteGymPassTypeCommand, ObjectId>
    {
        private readonly IGymPassTypeService _service;
        private readonly IMapper _mapper;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="service">Service to manage GymPassType domain</param>
        /// <param name="mapper">Mapper to map between models</param>
        public DeleteGymPassTypeCommandHandler(IGymPassTypeService service, IMapper mapper)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Handle DeleteGymPassTypeCommand command.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Id of deleted gym pass</returns>
        public Task<ObjectId> Handle(DeleteGymPassTypeCommand request, CancellationToken cancellationToken)
        {
            var id = _mapper.Map<string, ObjectId>(request.Id);
            return _service.Delete(id);
        }
    }
}
