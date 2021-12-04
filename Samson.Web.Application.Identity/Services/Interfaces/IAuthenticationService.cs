using System.Collections.Generic;

namespace Samson.Web.Application.Identity.Services.Interfaces
{
    /// <summary>
    /// Interface to handle authentication.
    /// </summary>
    public interface IAuthenticationService
    {
        /// <summary>
        /// Generate JWT token
        /// </summary>
        /// <param name="login">User login</param>
        /// <param name="id">User id</param>
        /// <param name="roles">User roles</param>
        /// <returns>JWT token</returns>
        public string GenerateJwtToken(string login, string id, IEnumerable<string> roles);
    }
}
