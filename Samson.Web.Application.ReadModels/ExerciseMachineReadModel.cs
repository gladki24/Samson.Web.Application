using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using Samson.Web.Application.Infrastructure.Attributes;
using Samson.Web.Application.Infrastructure.Configuration;
using Samson.Web.Application.Models.Dtos.ExerciseMachine;
using Samson.Web.Application.Persistence.Entities;
using Samson.Web.Application.ReadModels.Interfaces;

namespace Samson.Web.Application.ReadModels
{
    /// <summary>
    /// Default implementation of IExerciseMachineReadModel
    /// </summary>
    [ReadModel]
    public class ExerciseMachineReadModel : IExerciseMachineReadModel
    {
        private readonly IDatabaseConfiguration _databaseConfiguration;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="databaseConfiguration">Configuration of connection with database</param>
        /// <param name="mapper">Mapper to map between models</param>
        /// <param name="logger"></param>
        public ExerciseMachineReadModel(
            IDatabaseConfiguration databaseConfiguration,
            IMapper mapper,
            ILogger<ExerciseMachineReadModel> logger
        )
        {
            _databaseConfiguration =
                databaseConfiguration ?? throw new ArgumentNullException(nameof(databaseConfiguration));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Get ExerciseMachine from collection by id.
        /// </summary>
        /// <param name="id">Key</param>
        /// <returns>Dto</returns>
        public Task<ExerciseMachineDto> GetById(ObjectId id)
        {
            var query = GetGetAllExerciseMachinesQuery()
                .AppendStage<BsonDocument>("{ $match: { _id: " + id.ToJson() + " }}")
                .As<ExerciseMachineDto>();

            return query.SingleOrDefaultAsync();
        }

        /// <summary>
        /// Get all ExerciseMachine dtos from collection.
        /// </summary>
        /// <returns>Dtos list</returns>
        public Task<List<ExerciseMachineDto>> GetAll()
        {
            var query = GetGetAllExerciseMachinesQuery()
                .As<ExerciseMachineDto>();

            return query.ToListAsync();
        }

        private IAggregateFluent<BsonDocument> GetGetAllExerciseMachinesQuery()
        {
            var client = new MongoClient(_databaseConfiguration.ConnectionString);
            var database = client.GetDatabase(_databaseConfiguration.DatabaseName);

            var collection = database.GetCollection<ExerciseMachineEntity>("ExerciseMachineCollection");

            return collection
                .Aggregate()
                .AppendStage<BsonDocument>("{ $lookup: { from: 'GymObjectCollection', localField: 'LocalizationGymObjectId', foreignField: '_id', as: 'LocalizationGymObject'} }")
                .AppendStage<BsonDocument>("{ $unwind: '$LocalizationGymObject' }");
        }
    }
}