namespace Samson.Web.Application.Identity.Configuration
{
    /// <summary>
    /// Configuration for JWT token.
    /// </summary>
    public interface IJwtConfiguration
    {
        string Key { get; }
    }
}
