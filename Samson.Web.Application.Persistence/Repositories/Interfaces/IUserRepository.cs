using Samson.Web.Application.Infrastructure.Repository;
using Samson.Web.Application.Models.Domains;

namespace Samson.Web.Application.Persistence.Repositories.Interfaces
{
    /// <summary>
    /// Repository to get information about User.
    /// </summary>
    public interface IUserRepository : IRepository<User>
    {
        /// <summary>
        /// Get User by login.
        /// </summary>
        /// <param name="login">Login of user</param>
        public User GetByLogin(string login);
    }
}
