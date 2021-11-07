using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Samson.Web.Application.Infrastructure.Attributes;
using Samson.Web.Application.Models.Dtos.GymObject;
using Samson.Web.Application.Persistence.Entities;
using Samson.Web.Application.ReadModels.Interfaces;

namespace Samson.Web.Application.ReadModels
{
    /// <summary>
    /// Default implementation of IGymObjectReadModel
    /// </summary>
    [ReadModel]
    public class GymObjectReadModel : IGymObjectReadModel
    {
        private readonly IDatabaseConfiguration _databaseConfiguration;
        private readonly IMapper _mapper;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="databaseConfiguration">Configuration of connection with database</param>
        /// <param name="mapper">Mapper to map between models</param>
        public GymObjectReadModel(
            IDatabaseConfiguration databaseConfiguration,
            IMapper mapper
        )
        {
            _databaseConfiguration = databaseConfiguration ?? throw new ArgumentNullException(nameof(databaseConfiguration));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public Task<GymObjectDto> GetById(ObjectId id)
        {
            var client = new MongoClient(_databaseConfiguration.ConnectionString);
            var database = client.GetDatabase(_databaseConfiguration.DatabaseName);

            var collection = database.GetCollection<GymObjectEntity>("GymObjectCollection");

            var query = from gymObject in collection.AsQueryable()
                where gymObject.Id == id
                select gymObject;

            return query
                .SingleOrDefaultAsync()
                .ContinueWith(result => _mapper.Map<GymObjectDto>(result.Result));
        }

        public Task<List<GymObjectDto>> GetAll()
        {
            var client = new MongoClient(_databaseConfiguration.ConnectionString);
            var database = client.GetDatabase(_databaseConfiguration.DatabaseName);

            var collection = database.GetCollection<GymObjectEntity>("GymObjectCollection");

            var query = from gymObject in collection.AsQueryable()
                select gymObject;

            return query
                .ToListAsync()
                .ContinueWith(result => _mapper.Map<List<GymObjectDto>>(result.Result));
        }
    }
}