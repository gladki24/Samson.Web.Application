using System;
using MongoDB.Bson;
using Samson.Web.Application.Factories.Interfaces;
using Samson.Web.Application.Identity.Services.Interfaces;
using Samson.Web.Application.Infrastructure.Attributes;
using Samson.Web.Application.Models.DataStructures.User;
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

        public User Create(CreateUserDataStructure dataStructure) =>
            new User(ObjectId.GenerateNewId(), _hashService.HashPassword(dataStructure.Password), dataStructure);
    }
}
