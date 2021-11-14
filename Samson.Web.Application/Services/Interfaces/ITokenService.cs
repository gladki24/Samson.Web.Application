using System.Threading.Tasks;
using Samson.Web.Application.Models.DataStructures.User;

namespace Samson.Web.Application.Services.Interfaces
{
    /// <summary>
    /// JWT Token authentication service.
    /// </summary>
    public interface ITokenService
    {
        /// <summary>
        /// Authenticate User.
        /// </summary>
        /// <returns>JWT Token</returns>
        Task<string> Authenticate(AuthenticateUserDataStructure dataStructure);
    }
}
