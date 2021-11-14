using System.Threading.Tasks;
using MediatR;
using Samson.Web.Application.Models.DataStructures.User.Client;

namespace Samson.Web.Application.Services.Domain.Interfaces
{
    public interface IExtendClientPassDomainService
    {
        /// <summary>
        /// Extend Client gym pass.
        /// </summary>
        /// <param name="dataStructure">Data to extend Client's gym pass</param>
        public Task<Unit> Extend(ExtendClientPassDataStructure dataStructure);
    }
}
