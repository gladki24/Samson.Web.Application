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

        public EventReadModel(
            IDatabaseConfiguration databaseConfiguration,
            IMapper mapper
        )
        {
            _databaseConfiguration =
                databaseConfiguration ?? throw new ArgumentNullException(nameof(databaseConfiguration));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

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