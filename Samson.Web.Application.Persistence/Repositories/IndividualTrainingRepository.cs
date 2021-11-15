using AutoMapper;
using Samson.Web.Application.Infrastructure.Attributes;
using Samson.Web.Application.Infrastructure.Configuration;
using Samson.Web.Application.Infrastructure.Repository;
using Samson.Web.Application.Models.Domains;
using Samson.Web.Application.Persistence.Entities;

namespace Samson.Web.Application.Persistence.Repositories
{
    /// <summary>
    /// Repository to IndividualTrainingRepository domain.
    /// </summary>
    [Repository]
    public class IndividualTrainingRepository : MongoRepository<IndividualTraining, IndividualTrainingEntity>
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="databaseConfiguration">Default configuration of database</param>
        /// <param name="mapper">Mapper to map between types</param>
        public IndividualTrainingRepository(IDatabaseConfiguration databaseConfiguration, IMapper mapper)
            : base(databaseConfiguration, mapper) { }
    }
}
