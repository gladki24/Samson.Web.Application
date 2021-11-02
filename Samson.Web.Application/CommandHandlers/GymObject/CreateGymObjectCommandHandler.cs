﻿using System;
using MediatR;
using Samson.Web.Application.Commands.GymObject;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MongoDB.Bson;
using Samson.Web.Application.DataStructures;
using Samson.Web.Application.Infrastructure.Attributes;
using Samson.Web.Application.Services.Interfaces;

namespace Samson.Web.Application.CommandHandlers.GymObject
{
    /// <summary>
    /// CreateGymObjectCommand handler
    /// </summary>
    [CommandHandler]
    public class CreateGymObjectCommandHandler : IRequestHandler<CreateGymObjectCommand, ObjectId>
    {
        private readonly IGymObjectService _service;
        private readonly IMapper _mapper;

        /// <summary>
        /// Default constructor
        /// </summary>
        public CreateGymObjectCommandHandler(IGymObjectService service, IMapper mapper)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Handle CreateHymObjectCommand command
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
