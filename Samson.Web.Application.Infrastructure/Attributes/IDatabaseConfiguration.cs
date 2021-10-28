namespace Samson.Web.Application.Infrastructure.Attributes
{
    public interface IDatabaseConfiguration
    {
        string ConnectionString { get; }
        string DatabaseName { get; }
    }
}
