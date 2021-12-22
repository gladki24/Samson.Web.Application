using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Samson.Web.Application.Infrastructure.Attributes;
using Samson.Web.Application.Infrastructure.Configuration;
using Samson.Web.Application.Models.Dtos.GymPass;
using Samson.Web.Application.Persistence.Entities;
using Samson.Web.Application.ReadModels.Interfaces;

namespace Samson.Web.Application.ReadModels
{
    /// <summary>
    /// Default implementation of IGymPassReadModel
    /// </summary>
    [ReadModel]
    public class GymPassReadModel : IGymPassReadModel
    {
        private readonly IDatabaseConfiguration _databaseConfiguration;
        private readonly IMapper _mapper;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="databaseConfiguration">Configuration of connection with database</param>
        /// <param name="mapper">Mapper to map between models</param>
        public GymPassReadModel(
            IDatabaseConfiguration databaseConfiguration, IMapper mapper)
        {
            _databaseConfiguration =
                databaseConfiguration ?? throw new ArgumentNullException(nameof(databaseConfiguration));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Get GymPassType from collection by id.
        /// </summary>
        /// <param name="id">Key</param>
        /// <returns>Dto</returns>
        public Task<GymPassTypeDto> GetById(ObjectId id)
        {
            var client = new MongoClient(_databaseConfiguration.ConnectionString);
            var database = client.GetDatabase(_databaseConfiguration.DatabaseName);

            var collection = database.GetCollection<GymPassTypeEntity>("GymPassTypeCollection");

            var query = from pass in collection.AsQueryable()
                where pass.Id == id
                select pass;

            return query
                .SingleOrDefaultAsync()
                .ContinueWith(result => _mapper.Map<GymPassTypeDto>(result.Result));
        }

        /// <summary>
        /// Get all GypPassTypes from collection.
        /// </summary>
        /// <returns>Dtos list</returns>
        public Task<List<GymPassTypeDto>> GetAll()
        {
            var client = new MongoClient(_databaseConfiguration.ConnectionString);
            var database = client.GetDatabase(_databaseConfiguration.DatabaseName);

            var collection = database.GetCollection<GymPassTypeEntity>("GymPassTypeCollection");

            var query = from pass in collection.AsQueryable()
                select pass;

            return query
                .ToListAsync()
                .ContinueWith(result => _mapper.Map<List<GymPassTypeDto>>(result.Result));
        }
    }
}