using System;
using System.Threading.Tasks;
using MongoDB.Bson;
using Samson.Web.Application.Factories.Interfaces;
using Samson.Web.Application.Identity.Services.Interfaces;
using Samson.Web.Application.Infrastructure.Attributes;
using Samson.Web.Application.Models.DataStructures.User.PersonalTrainer;
using Samson.Web.Application.Models.Domains;
using Samson.Web.Application.Persistence.Repositories.Interfaces;
using Samson.Web.Application.Services.Interfaces;

namespace Samson.Web.Application.Services
{
    /// <summary>
    /// Application service to work with PersonalTrainer domain.
    /// </summary>
    [Service]
    public class PersonalTrainerService : UserService<PersonalTrainer>, IPersonalTrainerService
    {
        private readonly IUserFactory _factory;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="repository">Repository to manage PersonalTrainer entity</param>
        /// <param name="hashService">Service to hash and validate password</param>
        /// <param name="factory">Factory to create new PersonalTrainer account</param>
        public PersonalTrainerService(IPersonalTrainerRepository repository, IHashService hashService, IUserFactory factory)
            : base(repository, hashService)
        {
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        /// <summary>
        /// CreatePersonalTrainer User aggregate.
        /// </summary>
        /// <param name="dataStructure">Data to create User domain</param>
        /// <returns>Created User Id</returns>
        public Task<ObjectId> Create(CreatePersonalTrainerDataStructure dataStructure)
        {
            var trainer = _factory.CreatePersonalTrainer(dataStructure);
            return Repository.Create(trainer);
        }

        /// <summary>
        /// Update PersonalTrainer aggregate.
        /// </summary>
        /// <param name="dataStructure">Data to update PersonalTrainer domain</param>
        /// <returns>Updated PersonalTrainer Id</returns>
        public Task<ObjectId> Update(UpdatePersonalTrainerDataStructure dataStructure)
        {
            var trainer = GetOrThrow(dataStructure.Id);
            trainer.Update(dataStructure);
            return Repository.Update(dataStructure.Id, trainer);
        }
    }

}
