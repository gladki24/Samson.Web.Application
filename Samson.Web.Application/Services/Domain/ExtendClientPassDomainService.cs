using System;
using System.Threading.Tasks;
using MediatR;
using Samson.Web.Application.Infrastructure.Attributes;
using Samson.Web.Application.Infrastructure.Exceptions;
using Samson.Web.Application.Infrastructure.Repository;
using Samson.Web.Application.Models.DataStructures.User.Client;
using Samson.Web.Application.Models.Domains;
using Samson.Web.Application.Persistence.Repositories.Interfaces;
using Samson.Web.Application.Resources;
using Samson.Web.Application.Services.Domain.Interfaces;

namespace Samson.Web.Application.Services.Domain
{
    /// <summary>
    /// Domain service to extend Client's gym pass.
    /// </summary>
    [Service]
    public class ExtendClientPassDomainService : IExtendClientPassDomainService
    {
        private readonly IRepository<GymPassType> _gymPassTypeRepository;
        private readonly IClientRepository _clientRepository;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="gymPassTypeRepository">Repository to manage gymPass entity</param>
        /// <param name="clientRepository">Repository to manage client entity</param>
        public ExtendClientPassDomainService(
            IRepository<GymPassType> gymPassTypeRepository, IClientRepository clientRepository)
        {
            _gymPassTypeRepository =
                gymPassTypeRepository ?? throw new ArgumentNullException(nameof(gymPassTypeRepository));
            _clientRepository = clientRepository ?? throw new ArgumentNullException(nameof(clientRepository));
        }

        /// <summary>
        /// Extend Client gym pass.
        /// </summary>
        /// <param name="dataStructure">Data to extend Client's gym pass</param>
        public Task<Unit> Extend(ExtendClientPassDataStructure dataStructure)
        {
            var client = _clientRepository.Get(dataStructure.ClientId)
                         ?? throw new BusinessLogicException(ApplicationMessage.ClientNotFound);

            var gymPassType = _gymPassTypeRepository.Get(dataStructure.GymPassTypeId)
                              ?? throw new BusinessLogicException(ApplicationMessage.GymPassNotFound);

            client.ExtendPass(gymPassType);
            return _clientRepository.Update(dataStructure.ClientId, client)
                .ContinueWith(_ => new Unit());
        }
    }
}
