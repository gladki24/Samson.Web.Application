using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Samson.Web.Application.Infrastructure.Attributes;
using Samson.Web.Application.Infrastructure.Configuration;
using Samson.Web.Application.Models.Dtos.Event;
using Samson.Web.Application.Persistence.Entities;
using Samson.Web.Application.ReadModels.Interfaces;

namespace Samson.Web.Application.ReadModels
{
    /// <summary>
    /// Default implementation of IEventReadModel
    /// </summary>
    [ReadModel]
    public class EventReadModel : IEventReadModel
    {
        private readonly IDatabaseConfiguration _databaseConfiguration;
        private readonly IMapper _mapper;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="databaseConfiguration">Configuration of connection with database</param>
        /// <param name="mapper">Mapper to map between models</param>
        public EventReadModel(
            IDatabaseConfiguration databaseConfiguration,
            IMapper mapper
        )
        {
            _databaseConfiguration =
                databaseConfiguration ?? throw new ArgumentNullException(nameof(databaseConfiguration));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Get Event from collection by id.
        /// </summary>
        /// <param name="id">Key</param>
        /// <returns>Dto</returns>
        public Task<EventDto> GetById(ObjectId id)
        {
            var client = new MongoClient(_databaseConfiguration.ConnectionString);
            var database = client.GetDatabase(_databaseConfiguration.DatabaseName);

            var collection = database.GetCollection<EventEntity>("EventCollection");

            var query = from @event in collection.AsQueryable()
                where @event.Id == id
                select @event;

            return query
                .SingleOrDefaultAsync()
                .ContinueWith(result => _mapper.Map<EventDto>(result.Result));
        }

        /// <summary>
        /// Get all Events from collection.
        /// </summary>
        /// <returns>Dtos list</returns>
        public Task<List<EventDto>> GetAll()
        {
            var client = new MongoClient(_databaseConfiguration.ConnectionString);
            var database = client.GetDatabase(_databaseConfiguration.DatabaseName);

            var collection = database.GetCollection<EventEntity>("EventCollection");

            var query = from @event in collection.AsQueryable()
                select @event;

            return query
                .ToListAsync()
                .ContinueWith(result => _mapper.Map<List<EventDto>>(result.Result));
        }
    }
}