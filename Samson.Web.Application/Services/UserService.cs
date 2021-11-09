using System;
using System.Threading.Tasks;
using MongoDB.Bson;
using Samson.Web.Application.Factories.Interfaces;
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
    /// Application service to work with User.
    /// </summary>
    [Service]
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IUserFactory _factory;
        private readonly IAuthenticationService _authenticationService;
        private readonly IHashService _hashService;

        public UserService(IUserRepository repository, IUserFactory factory, IAuthenticationService authenticationService, IHashService hashService)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
            _authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
            _hashService = hashService ?? throw new ArgumentNullException(nameof(hashService));
        }

        public Task<ObjectId> Create(CreateUserDataStructure dataStructure)
        {
            var user = _factory.Create(dataStructure);
            return _repository.Create(user);
        }

        public Task<ObjectId> Update(UpdateUserDataStructure dataStructure)
        {
            var user = GetOrThrow(dataStructure.Id);
            user.Update(dataStructure);
            return _repository.Update(dataStructure.Id, user);
        }

        public Task<ObjectId> Delete(DeleteUserDataStructure dataStructure)
        {
            var user = GetOrThrow(dataStructure.Id);

            if (user.Password != dataStructure.Password)
            {
                throw new BusinessLogicException("Invalid password. Valid password is required to delete account");
            }

            return _repository.Remove(user);
        }

        public Task<string> Authenticate(AuthenticateUserDataStructure dataStructure)
        {
            var user = GetByLoginOrThrow(dataStructure.Login);

            if (!_hashService.Verify(dataStructure.Password, user.Password))
            {
                throw new BusinessLogicException("User password is invalid.");
            }

            return Task.FromResult(_authenticationService.GenerateJwtToken(dataStructure.Login));
        }

        private User GetOrThrow(ObjectId id)
        {
            return _repository.Get(id) ?? throw new BusinessLogicException("User not found.");
        }

        private User GetByLoginOrThrow(string login)
        {
            return _repository.GetByLogin(login) ?? throw new BusinessLogicException("User login is invalid.");
        }
    }
}
