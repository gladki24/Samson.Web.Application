using System;
using System.Threading.Tasks;
using Samson.Web.Application.Identity.Services.Interfaces;
using Samson.Web.Application.Infrastructure.Attributes;
using Samson.Web.Application.Infrastructure.Exceptions;
using Samson.Web.Application.Models.DataStructures.User;
using Samson.Web.Application.Models.Domains;
using Samson.Web.Application.Persistence.Repositories.Interfaces;
using Samson.Web.Application.Services.Interfaces;

namespace Samson.Web.Application.Services
{
    /// <summary>
    /// Default implementation of ITokenService.
    /// </summary>
    [Service]
    public class TokenService : ITokenService
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IHashService _hashService;
        private readonly IUserRepository _repository;

        public TokenService(IUserRepository repository, IAuthenticationService authenticationService, IHashService hashService)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
            _hashService = hashService ?? throw new ArgumentNullException(nameof(hashService));
        }

        public Task<string> Authenticate(AuthenticateUserDataStructure dataStructure)
        {
            var user = GetByLoginOrThrow(dataStructure.Login);

            if (!_hashService.Verify(dataStructure.Password, user.Password))
                throw new BusinessLogicException("User password is invalid.");

            return Task.FromResult(_authenticationService.GenerateJwtToken(dataStructure.Login));
        }

        private User GetByLoginOrThrow(string login)
        {
            return _repository.GetByLogin(login) ?? throw new BusinessLogicException("User login is invalid.");
        }
    }
}
