using AutoMapper;
using MongoDB.Driver;
using Samson.Web.Application.Infrastructure.Attributes;
using Samson.Web.Application.Infrastructure.Configuration;
using Samson.Web.Application.Infrastructure.Repository;
using Samson.Web.Application.Models.Domains;
using Samson.Web.Application.Persistence.Entities;
using Samson.Web.Application.Persistence.Repositories.Interfaces;

namespace Samson.Web.Application.Persistence.Repositories
{
    /// <summary>
    /// Repository of User domain.
    /// </summary>
    [Repository]
    public class UserRepository : MongoRepository<User, UserEntity>, IUserRepository
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="databaseConfiguration">Configuration to connect database</param>
        /// <param name="mapper">Mapper to map between models</param>
        public UserRepository(IDatabaseConfiguration databaseConfiguration, IMapper mapper)
            : base(databaseConfiguration, mapper)
        {
        }

        public User GetByLogin(string login)
        {
            var userEntity = Collection
                .Find(model => model.Login == login)
                .FirstOrDefault();
            return Mapper.Map<UserEntity, User>(userEntity);
        }
    }
}
