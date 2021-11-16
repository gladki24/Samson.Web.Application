using System.Collections.Generic;
using AutoMapper;
using MongoDB.Bson;
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
    /// Repository to manage entrance entities in database.
    /// </summary>
    [Repository]
    public class EntranceRepository : MongoRepository<Entrance, EntranceEntity>, IEntranceRepository
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="databaseConfiguration">Configuration to connect database</param>
        /// <param name="mapper">Mapper to map between models</param>
        public EntranceRepository(IDatabaseConfiguration databaseConfiguration, IMapper mapper) : base(databaseConfiguration, mapper)
        {
        }

        public List<Entrance> GetAllByGymObjectIdAndClientId(ObjectId gymObjectId, ObjectId clientId)
        {
            var entranceEntities = Collection
                .Find(model => model.GymObjectId == gymObjectId && model.ClientId == clientId)
                .ToList();
            return Mapper.Map<List<EntranceEntity>, List<Entrance>>(entranceEntities);
        }

        public List<Entrance> GetAllByGymObjectId(ObjectId gymObjectId)
        {
            var entranceEntities = Collection
                .Find(model => model.GymObjectId == gymObjectId)
                .ToList();
            return Mapper.Map<List<EntranceEntity>, List<Entrance>>(entranceEntities);
        }
    }
}
