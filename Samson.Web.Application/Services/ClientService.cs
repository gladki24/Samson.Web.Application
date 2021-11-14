using System;
using System.Threading.Tasks;
using MediatR;
using MongoDB.Bson;
using Samson.Web.Application.Factories.Interfaces;
using Samson.Web.Application.Identity.Services.Interfaces;
using Samson.Web.Application.Infrastructure.Attributes;
using Samson.Web.Application.Infrastructure.Exceptions;
using Samson.Web.Application.Models.DataStructures.User.Client;
using Samson.Web.Application.Models.Domains;
using Samson.Web.Application.Persistence.Repositories.Interfaces;
using Samson.Web.Application.Services.Domain.Interfaces;
using Samson.Web.Application.Services.Interfaces;

namespace Samson.Web.Application.Services
{
    /// <summary>
    /// Application service to work with Client.
    /// </summary>
    [Service]
    public class ClientService : UserService<Client>, IClientService
    {
        private readonly IExtendClientPassDomainService _extendClientPassDomainService;
        private readonly IUserFactory _factory;

        public ClientService(IClientRepository repository, IHashService hashService, IUserFactory factory,
            IExtendClientPassDomainService extendClientPassDomainService)
            : base(repository, hashService)
        {
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
            _extendClientPassDomainService = extendClientPassDomainService ??
                                             throw new ArgumentNullException(nameof(extendClientPassDomainService));
        }

        public Task<ObjectId> Register(RegisterClientDataStructure dataStructure)
        {
            if (Repository.GetByLogin(dataStructure.Login) != null)
                throw new BusinessLogicException("An account with this login already exists.");

            var client = _factory.CreateClient(dataStructure);
            return Repository.Create(client);
        }

        public Task<ObjectId> Update(UpdateClientDataStructure dataStructure)
        {
            var client = GetOrThrow(dataStructure.Id);
            client.Update(dataStructure);
            return Repository.Update(dataStructure.Id, client);
        }

        public Task<Unit> ExtendGymPass(ExtendClientPassDataStructure dataStructure)
        {
            return _extendClientPassDomainService.Extend(dataStructure);
        }
    }
}
