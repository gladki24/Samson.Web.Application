using System;
using System.Threading.Tasks;
using MongoDB.Bson;
using Samson.Web.Application.Identity.Services.Interfaces;
using Samson.Web.Application.Infrastructure.Attributes;
using Samson.Web.Application.Infrastructure.Exceptions;
using Samson.Web.Application.Models.DataStructures.User;
using Samson.Web.Application.Models.Domains;
using Samson.Web.Application.Persistence.Repositories.Interfaces;
using Samson.Web.Application.Resources;
using Samson.Web.Application.Services.Interfaces;

namespace Samson.Web.Application.Services
{
    /// <summary>
    /// Application service to work with User.
    /// </summary>
    [Service]
    public class UserService<TUser> : IUserService where TUser : User
    {
        protected readonly IUserRepository<TUser> Repository;
        private readonly IHashService _hashService;

        public UserService(IUserRepository<TUser> repository, IHashService hashService)
        {
            Repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _hashService = hashService ?? throw new ArgumentNullException(nameof(hashService));
        }

        public Task<ObjectId> Delete(DeleteUserDataStructure dataStructure)
        {
            var user = GetOrThrow(dataStructure.Id);

            if (!_hashService.Verify(dataStructure.Password, user.Password))
                throw new BusinessLogicException(ApplicationMessage.InvalidPasswordToDelete);

            return Repository.Remove(user);
        }

        protected TUser GetOrThrow(ObjectId id)
        {
            return Repository.Get(id) ?? throw new BusinessLogicException(ApplicationMessage.UserNotFound);
        }
    }
}