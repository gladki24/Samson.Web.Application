using System;
using System.Threading.Tasks;
using MongoDB.Bson;
using Samson.Web.Application.Factories.Interfaces;
using Samson.Web.Application.Infrastructure.Attributes;
using Samson.Web.Application.Infrastructure.Exceptions;
using Samson.Web.Application.Infrastructure.Repository;
using Samson.Web.Application.Models.DataStructures.GymPass;
using Samson.Web.Application.Models.Domains;
using Samson.Web.Application.Resources;
using Samson.Web.Application.Services.Interfaces;

namespace Samson.Web.Application.Services
{
    /// <summary>
    /// Application service to work with GymPassType.
    /// </summary>
    [Service]
    public class GymPassTypeService : IGymPassTypeService
    {
        private readonly IRepository<GymPassType> _repository;
        private readonly IGymPassTypeFactory _factory;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="repository">Repository to manage gymPassType entity</param>
        /// <param name="factory">Factory to create new GymPassType</param>
        public GymPassTypeService(IRepository<GymPassType> repository, IGymPassTypeFactory factory)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        /// <summary>
        /// Create GymPassType aggregate.
        /// </summary>
        /// <param name="dataStructure">Data to create GymPassType domain</param>
        /// <returns>GymPassType Id</returns>
        public Task<ObjectId> Create(CreateGymPassTypeDataStructure dataStructure)
        {
            var gymPassType = _factory.CreateGymPassType(dataStructure);
            return _repository.Create(gymPassType);
        }

        /// <summary>
        /// Update GymPassType aggregate.
        /// </summary>
        /// <param name="dataStructure">Data to update GymPassType domain</param>
        /// <returns>GymPassType Id</returns>
        public Task<ObjectId> Update(UpdateGymPassTypeDataStructure dataStructure)
        {
            var gymPassType = GetOrThrow(dataStructure.Id);
            gymPassType.Update(dataStructure);
            return _repository.Update(gymPassType.Id, gymPassType);
        }

        /// <summary>
        /// Delete GymPassType aggregate.
        /// </summary>
        /// <param name="id">Id of GymPassType domain</param>
        /// <returns>GymPassType Id</returns>
        public Task<ObjectId> Delete(ObjectId id)
        {
            var gymPassType = GetOrThrow(id);
            return _repository.Remove(gymPassType);
        }

        private GymPassType GetOrThrow(ObjectId id)
        {
            return _repository.Get(id) ?? throw new BusinessLogicException(ApplicationMessage.GymPassNotFound);
        }
    }
}
