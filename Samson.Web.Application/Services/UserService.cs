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

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="repository">Repository to manage user entity</param>
        /// <param name="hashService">Service to validate password</param>
        public UserService(IUserRepository<TUser> repository, IHashService hashService)
        {
            Repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _hashService = hashService ?? throw new ArgumentNullException(nameof(hashService));
        }

        /// <summary>
        /// Delete User aggregate.
        /// </summary>
        /// <param name="dataStructure">Data to delete User domain</param>
        /// <returns>Deleted User Id</returns>
        public Task<ObjectId> Delete(DeleteUserDataStructure dataStructure)
        {
            var user = GetOrThrow(dataStructure.Id);

            if (!_hashService.Verify(dataStructure.Password, user.Password))
                throw new BusinessLogicException(ApplicationMessage.InvalidPasswordToDelete);
            
            user.Archive();
            return Repository.Update(dataStructure.Id, user);
        }

        protected TUser GetOrThrow(ObjectId id)
        {
            return Repository.Get(id) ?? throw new BusinessLogicException(ApplicationMessage.UserNotFound);
        }
    }
}