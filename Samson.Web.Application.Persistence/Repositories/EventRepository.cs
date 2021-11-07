using AutoMapper;
using Samson.Web.Application.Infrastructure.Attributes;
using Samson.Web.Application.Infrastructure.Configuration;
using Samson.Web.Application.Infrastructure.Repository;
using Samson.Web.Application.Models.Domains;
using Samson.Web.Application.Persistence.Entities;

namespace Samson.Web.Application.Persistence.Repositories
{
    /// <summary>
    /// Repository of Event domain
    /// </summary>
    [Repository]
    public class EventRepository : MongoRepository<Event, EventEntity>
    {
        public EventRepository(IDatabaseConfiguration databaseConfiguration, IMapper mapper)
            : base(databaseConfiguration, mapper)
        { }
    }
}
