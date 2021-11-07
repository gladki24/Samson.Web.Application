using System;

namespace Samson.Web.Application.Infrastructure.Configuration
{
    /// <summary>
    /// Configuration for database connection.
    /// </summary>
    public class DatabaseConfiguration : IDatabaseConfiguration
    {
        public string ConnectionString { get; }
        public string DatabaseName { get; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="connectionString">Connection string to connect to database</param>
        public DatabaseConfiguration(string connectionString, string databaseName)
        {
            ConnectionString = connectionString ?? throw new ApplicationException("Connection string to database has to be provided.");
            DatabaseName = databaseName ?? throw new ApplicationException("Database name has to be provided.");
        }
    }
}
