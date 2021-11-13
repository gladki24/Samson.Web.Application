using Microsoft.Extensions.Logging;
using MongoDB.Driver;

namespace Samson.Web.Application.Infrastructure.Configuration
{
    /// <summary>
    /// Configuration for database connection.
    /// </summary>
    public interface IDatabaseConfiguration
    {
        string ConnectionString { get; }
        string DatabaseName { get; }

        /// <summary>
        /// Provide client to make requests to MongoDB database API
        /// </summary>
        /// <param name="logger">Logger to trace</param>
        /// <returns>MongoClient</returns>
        public MongoClient CreateClient(ILogger logger);
    }
}
