using System;
using System.Threading.Tasks;
using AutoMapper;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Samson.Web.Application.Infrastructure.Attributes;
using Samson.Web.Application.Infrastructure.Configuration;
using Samson.Web.Application.Models.Dtos.User;
using Samson.Web.Application.ReadModels.Interfaces;

namespace Samson.Web.Application.ReadModels
{
    /// <summary>
    /// Default implementation of IUserReadModel
    /// </summary>
    [ReadModel]
    public class UserReadModel : IUserReadModel
    {
        private readonly IDatabaseConfiguration _databaseConfiguration;
        private readonly IMapper _mapper;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="databaseConfiguration">Configuration of connection with database</param>
        /// <param name="mapper">Mapper to map between models</param>
        public UserReadModel(
            IDatabaseConfiguration databaseConfiguration, IMapper mapper)
        {
            _databaseConfiguration =
                databaseConfiguration ?? throw new ArgumentNullException(nameof(databaseConfiguration));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public Task<UserDto> GetById(ObjectId id)
        {
            var client = new MongoClient(_databaseConfiguration.ConnectionString);
            var database = client.GetDatabase(_databaseConfiguration.DatabaseName);

            var collection = database.GetCollection<UserDto>("UserCollection");

            var query = from user in collection.AsQueryable()
                where user.Id == id
                select new UserDto(user.Id, user.Login);

            return query
                .SingleOrDefaultAsync()
                .ContinueWith(result => _mapper.Map<UserDto>(result.Result));
        }
    }
}