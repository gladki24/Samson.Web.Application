using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Samson.Web.Application.Infrastructure.Attributes;
using Samson.Web.Application.Infrastructure.Configuration;
using Samson.Web.Application.Models.Dtos.IndividualTraining;
using Samson.Web.Application.Persistence.Entities;
using Samson.Web.Application.ReadModels.Interfaces;

namespace Samson.Web.Application.ReadModels
{
    /// <summary>
    /// Default implementation of IIndividualTrainingReadModel
    /// </summary>
    [ReadModel]
    public class IndividualTrainingReadModel : IIndividualTrainingReadModel
    {
        private readonly IDatabaseConfiguration _databaseConfiguration;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="databaseConfiguration">Configuration of connection with database</param>
        /// <param name="mapper">Mapper to map between models</param>
        public IndividualTrainingReadModel(IDatabaseConfiguration databaseConfiguration, IMapper mapper, ILogger<IndividualTrainingReadModel> logger)
        {
            _databaseConfiguration =
                databaseConfiguration ?? throw new ArgumentNullException(nameof(databaseConfiguration));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public Task<IndividualTrainingDto> GetById(ObjectId id)
        {
            var client = _databaseConfiguration.CreateClient(_logger);
            var database = client.GetDatabase(_databaseConfiguration.DatabaseName);

            var collection = database.GetCollection<IndividualTrainingEntity>("IndividualTrainingCollection");

            var query = collection
                .Aggregate()
                .Match(training => training.Id == id)
                .As<IndividualTrainingEntity>();

            return query
                .SingleOrDefaultAsync()
                .ContinueWith(entity => _mapper.Map<IndividualTrainingDto>(entity.Result));
        }

        public Task<List<IndividualTrainingDto>> GetAll()
        {
            var client = _databaseConfiguration.CreateClient(_logger);
            var database = client.GetDatabase(_databaseConfiguration.DatabaseName);

            var collection = database.GetCollection<IndividualTrainingEntity>("IndividualTrainingCollection");

            var query = collection
                .Aggregate()
                .As<IndividualTrainingEntity>();

            return query
                .ToListAsync()
                .ContinueWith(entities => entities.Result.Select(entity => _mapper.Map<IndividualTrainingDto>(entity)).ToList());
        }
    }
}