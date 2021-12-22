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

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="hashService">Service to hash password</param>
        public UserFactory(IHashService hashService)
        {
            _hashService = hashService ?? throw new ArgumentNullException(nameof(hashService));
        }

        /// <summary>
        /// Create PersonalTrainer account model
        /// </summary>
        /// <param name="dataStructure">Information about personal trainer account</param>
        /// <returns>PersonalTrainer</returns>
        public PersonalTrainer CreatePersonalTrainer(CreatePersonalTrainerDataStructure dataStructure)
            => new PersonalTrainer(ObjectId.GenerateNewId(), _hashService.HashPassword(dataStructure.Password), dataStructure);

        /// <summary>
        /// Create Client account model
        /// </summary>
        /// <param name="dataStructure">Information about Client</param>
        /// <returns>Client</returns>
        public Client CreateClient(RegisterClientDataStructure dataStructure)
            => new Client(ObjectId.GenerateNewId(), _hashService.HashPassword(dataStructure.Password), dataStructure);
    }
}
