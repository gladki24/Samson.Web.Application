using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Samson.Web.Application.Commands.User;
using Samson.Web.Application.Infrastructure.Attributes;
using Samson.Web.Application.Models.DataStructures.User;
using Samson.Web.Application.Services.Interfaces;

namespace Samson.Web.Application.CommandHandlers.User
{
    /// <summary>
    /// LoginUserCommand command handler.
    /// </summary>
    [CommandHandler]
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, string>
    {
        private readonly ITokenService _service;
        private readonly IMapper _mapper;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="service">Service to manage User domain</param>
        /// <param name="mapper">Mapper to map between models</param>
        public LoginUserCommandHandler(ITokenService service, IMapper mapper)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Handle LoginUserCommand command.
        /// </summary>
        /// <param name="request">Command</param>
        /// <param name="cancellationToken">Cancellation notification</param>
        /// <returns>JWT token to store in client application</returns>
        public Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var dataStructure = _mapper.Map<LoginUserCommand, AuthenticateUserDataStructure>(request);
            return _service.Authenticate(dataStructure);
        }
    }
}
