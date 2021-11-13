using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Samson.Web.Application.Infrastructure.Attributes;
using Samson.Web.Application.Infrastructure.Configuration;
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
        private readonly ILogger _logger;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="databaseConfiguration">Configuration of connection with database</param>
        /// <param name="mapper">Mapper to map between models</param>
        /// <param name="logger">Log information about database queries</param>
        public GymObjectReadModel(
            IDatabaseConfiguration databaseConfiguration,
            IMapper mapper,
            ILogger<GymObjectReadModel> logger
        )
        {
            _databaseConfiguration = databaseConfiguration ?? throw new ArgumentNullException(nameof(databaseConfiguration));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
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
            var client = _databaseConfiguration.CreateClient(_logger);
            var database = client.GetDatabase(_databaseConfiguration.DatabaseName);

            var collection = database.GetCollection<GymObjectEntity>("GymObjectCollection");

            var query = from gymObject in collection.AsQueryable()
                select gymObject;

            return query
                .ToListAsync()
                .ContinueWith(result => _mapper.Map<List<GymObjectDto>>(result.Result));
        }

        public Task<GymRoomDetailsDto> GetRoomById(ObjectId id)
        {
            var query = GetGetAllGymRoomDetailsQuery()
                .AppendStage<BsonDocument>("{ $match: { _id: " + id.ToJson() + " }}");

            return query.As<GymRoomDetailsDto>().SingleOrDefaultAsync();
        }

        public Task<List<GymRoomDetailsDto>> GetAllRooms()
        {
            return GetGetAllGymRoomDetailsQuery()
                .As<GymRoomDetailsDto>()
                .ToListAsync();
        }

        private IAggregateFluent<BsonDocument> GetGetAllGymRoomDetailsQuery()
        {
            var client = _databaseConfiguration.CreateClient(_logger);
            var database = client.GetDatabase(_databaseConfiguration.DatabaseName);

            var collection = database.GetCollection<GymObjectEntity>("GymObjectCollection");

            return collection
                .Aggregate()
                .AppendStage<BsonDocument>("{ $addFields: { 'Rooms.GymObject': '$$ROOT' }}")
                .AppendStage<BsonDocument>("{ $unwind: '$Rooms' }")
                .AppendStage<BsonDocument>("{ $replaceRoot: { newRoot: '$Rooms'}}");
        }
    }
}