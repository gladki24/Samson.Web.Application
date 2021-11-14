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
    /// Generic repository of User domain.
    /// </summary>
    public abstract class UserRepository<TUser, TUserEntity>
        : MongoRepository<TUser, TUserEntity> where TUser : User where TUserEntity : UserEntity
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="databaseConfiguration">Configuration to connect database</param>
        /// <param name="mapper">Mapper to map between models</param>
        public UserRepository(IDatabaseConfiguration databaseConfiguration, IMapper mapper)
            : base(databaseConfiguration, mapper, $"{typeof(User).Name}Collection")
        {
        }

        public TUser GetByLogin(string login)
        {
            var userEntity = Collection
                .Find(model => model.Login == login)
                .FirstOrDefault();
            return Mapper.Map<TUserEntity, TUser>(userEntity);
        }
    }

    /// <summary>
    /// Repository of generic User domain.
    /// </summary>
    [Repository]
    public class UserRepository : UserRepository<User, UserEntity>, IUserRepository
    {
        public UserRepository(IDatabaseConfiguration databaseConfiguration, IMapper mapper)
            : base(databaseConfiguration, mapper)
        {
        }
    }
}
