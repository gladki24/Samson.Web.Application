namespace Samson.Web.Application.Infrastructure.Configuration
{
    /// <summary>
    /// Configuration for database connection.
    /// </summary>
    public interface IDatabaseConfiguration
    {
        string ConnectionString { get; }
        string DatabaseName { get; }
    }
}
