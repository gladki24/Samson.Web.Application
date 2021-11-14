using Samson.Web.Application.Infrastructure.Repository;
using Samson.Web.Application.Models.Domains;

namespace Samson.Web.Application.Persistence.Repositories.Interfaces
{
    /// <summary>
    /// Generic repository to get information about User.
    /// </summary>
    public interface IUserRepository<TUser> : IRepository<TUser> where TUser : User
    {
        /// <summary>
        /// Get User by login.
        /// </summary>
        /// <param name="login">Login of user</param>
        public TUser GetByLogin(string login);
    }

    /// <summary>
    /// Repository to get information about User.
    /// </summary>
    public interface IUserRepository : IUserRepository<User>
    {
    }
}



