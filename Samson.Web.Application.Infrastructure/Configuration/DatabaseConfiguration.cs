using Samson.Web.Application.Infrastructure.Attributes;

namespace Samson.Web.Application.Infrastructure.Configuration
{
    public class DatabaseConfiguration : IDatabaseConfiguration
    {
        public string ConnectionString { get; }

        public DatabaseConfiguration(string connectionString)
        {
            ConnectionString = connectionString;
        }
    }
}
