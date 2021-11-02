using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MongoDB.Bson;
using Samson.Web.Application.Commands.GymObject;
using Samson.Web.Application.Infrastructure.Attributes;
using Samson.Web.Application.Services.Interfaces;

namespace Samson.Web.Application.CommandHandlers.GymObject
{
    /// <summary>
    /// DeleteGymObjectCommand command handler.
    /// </summary>
    [CommandHandler]
    public class DeleteGymObjectCommandHandler : IRequestHandler<DeleteGymObjectCommand, ObjectId>
    {
        private readonly IGymObjectService _service;
        private readonly IMapper _mapper;

        /// <summary>
        /// Default constructor
        /// </summary>
        public DeleteGymObjectCommandHandler(
            IGymObjectService service,
            IMapper mapper
            )
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Handle DeleteGymObjectCommand command
        /// </summary>
        /// <param name="request">command</param>
        /// <param name="cancellationToken">cancellation notification</param>
        /// <returns>void</returns>
        public Task<ObjectId> Handle(DeleteGymObjectCommand request, CancellationToken cancellationToken)
        {
            var id = _mapper.Map<string, ObjectId>(request.Id);
            return _service.Delete(id);
        }
    }
}
