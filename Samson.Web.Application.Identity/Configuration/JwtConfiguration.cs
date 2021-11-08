using System;

namespace Samson.Web.Application.Identity.Configuration
{
    /// <summary>
    /// Configuration for JWT token.
    /// </summary>
    public class JwtConfiguration : IJwtConfiguration
    {
        public string Key { get; }

        public JwtConfiguration(string key)
        {
            Key = key ?? throw new ApplicationException("Key for JWT token has to be provided");
        }
    }
}
