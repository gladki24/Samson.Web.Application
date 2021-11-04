using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MongoDB.Bson;
using Samson.Web.Application.Commands.GymObject;
using Samson.Web.Application.Infrastructure.Attributes;
using Samson.Web.Application.Models.DataStructures;
using Samson.Web.Application.Services.Interfaces;

namespace Samson.Web.Application.CommandHandlers.GymObject
{
    /// <summary>
    /// UpdateGymObjectCommand command handler.
    /// </summary>
    [CommandHandler]
    public class UpdateGymObjectCommandHandler : IRequestHandler<UpdateGymObjectCommand, ObjectId>
    {
        private readonly IGymObjectService _service;
        private readonly IMapper _mapper;

        /// <summary>
        /// Default constructor
        /// </summary>
        public UpdateGymObjectCommandHandler(IGymObjectService service, IMapper mapper)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Handle UpdateGymObjectCommand command
        /// </summary>
        /// <param name="request">command</param>
        /// <param name="cancellationToken">cancellation notification</param>
        /// <returns>void</returns>
        public Task<ObjectId> Handle(UpdateGymObjectCommand request, CancellationToken cancellationToken)
        {
            var dataStructure = _mapper.Map<UpdateGymObjectCommand, UpdateGymObjectDataStructure>(request);
            return _service.Update(dataStructure);
        }
    }
}
