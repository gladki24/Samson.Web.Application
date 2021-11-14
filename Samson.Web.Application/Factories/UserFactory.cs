using System;
using MongoDB.Bson;
using Samson.Web.Application.Factories.Interfaces;
using Samson.Web.Application.Identity.Services.Interfaces;
using Samson.Web.Application.Infrastructure.Attributes;
using Samson.Web.Application.Models.DataStructures.User.Client;
using Samson.Web.Application.Models.DataStructures.User.PersonalTrainer;
using Samson.Web.Application.Models.Domains;

namespace Samson.Web.Application.Factories
{
    /// <summary>
    /// Factory to create User domain.
    /// </summary>
    [Factory]
    public class UserFactory : IUserFactory
    {
        private readonly IHashService _hashService;

        public UserFactory(IHashService hashService)
        {
            _hashService = hashService ?? throw new ArgumentNullException(nameof(hashService));
        }

        public PersonalTrainer CreatePersonalTrainer(CreatePersonalTrainerDataStructure dataStructure)
            => new PersonalTrainer(ObjectId.GenerateNewId(), _hashService.HashPassword(dataStructure.Password), dataStructure);

        public Client CreateClient(RegisterClientDataStructure dataStructure)
            => new Client(ObjectId.GenerateNewId(), _hashService.HashPassword(dataStructure.Password), dataStructure);
    }
}
