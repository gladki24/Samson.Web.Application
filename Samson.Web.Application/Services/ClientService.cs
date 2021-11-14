using System;
using System.Threading.Tasks;
using MongoDB.Bson;
using Samson.Web.Application.Factories.Interfaces;
using Samson.Web.Application.Identity.Services.Interfaces;
using Samson.Web.Application.Infrastructure.Attributes;
using Samson.Web.Application.Models.DataStructures.User.Client;
using Samson.Web.Application.Models.Domains;
using Samson.Web.Application.Persistence.Repositories.Interfaces;
using Samson.Web.Application.Services.Interfaces;

namespace Samson.Web.Application.Services
{
    /// <summary>
    /// Application service to work with Client.
    /// </summary>
    [Service]
    public class ClientService : UserService<Client>, IClientService
    {
        private readonly IUserFactory _factory;

        public ClientService(IUserRepository<Client> repository, IHashService hashService, IUserFactory factory)
            : base(repository, hashService)
        {
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        public Task<ObjectId> Register(RegisterClientDataStructure dataStructure)
        {
            var client = _factory.CreateClient(dataStructure);
            return Repository.Create(client);
        }

        public Task<ObjectId> Update(UpdateClientDataStructure dataStructure)
        {
            var client = GetOrThrow(dataStructure.Id);
            client.Update(dataStructure);
            return Repository.Update(dataStructure.Id, client);
        }
    }
}
