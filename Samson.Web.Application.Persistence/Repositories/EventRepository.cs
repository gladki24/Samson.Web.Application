using AutoMapper;
using Samson.Web.Application.Infrastructure.Attributes;
using Samson.Web.Application.Infrastructure.Configuration;
using Samson.Web.Application.Infrastructure.Repository;
using Samson.Web.Application.Models.Domains;
using Samson.Web.Application.Persistence.Entities;

namespace Samson.Web.Application.Persistence.Repositories
{
    /// <summary>
    /// Repository of Event domain.
    /// </summary>
    [Repository]
    public class EventRepository : MongoRepository<Event, EventEntity>
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="databaseConfiguration">Configuration to connect database</param>
        /// <param name="mapper">Mapper to map between models</param>
        public EventRepository(IDatabaseConfiguration databaseConfiguration, IMapper mapper)
            : base(databaseConfiguration, mapper)
        { }
    }
}
