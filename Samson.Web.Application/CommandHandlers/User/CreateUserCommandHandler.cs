using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MongoDB.Bson;
using Samson.Web.Application.Commands.User;
using Samson.Web.Application.Infrastructure.Attributes;
using Samson.Web.Application.Models.DataStructures.User;
using Samson.Web.Application.Services.Interfaces;

namespace Samson.Web.Application.CommandHandlers.User
{
    /// <summary>
    /// CreateUserCommand command handler.
    /// </summary>
    [CommandHandler]
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ObjectId>
    {
        private readonly IUserService _service;
        private readonly IMapper _mapper;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="service">Service to manage User domain</param>
        /// <param name="mapper">Mapper to map between models</param>
        public CreateUserCommandHandler(IUserService service, IMapper mapper)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Handle CreateUserCommand command.
        /// </summary>
        /// <param name="request">Command</param>
        /// <param name="cancellationToken">Cancellation notification</param>
        /// <returns></returns>
        public Task<ObjectId> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var dataStructure = _mapper.Map<CreateUserCommand, CreateUserDataStructure>(request);
            return _service.Create(dataStructure);
        }
    }
}
