using System;
using System.Threading.Tasks;
using MongoDB.Bson;
using Samson.Web.Application.Factories.Interfaces;
using Samson.Web.Application.Infrastructure.Attributes;
using Samson.Web.Application.Infrastructure.Repository;
using Samson.Web.Application.Models.DataStructures;
using Samson.Web.Application.Models.DataStructures.GymObject;
using Samson.Web.Application.Models.Domains;
using Samson.Web.Application.Services.Interfaces;

namespace Samson.Web.Application.Services
{
    /// <summary>
    /// Application service to work with GymObject. Default implementation of IGymObjectService
    /// </summary>
    [Service]
    public class GymObjectService : IGymObjectService
    {
        private readonly IRepository<GymObject> _repository;
        private readonly IGymObjectFactory _factory;

        /// <summary>
        /// Default constructor
        /// </summary>
        public GymObjectService(IRepository<GymObject> repository, IGymObjectFactory factory)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        public Task<ObjectId> Create(CreateGymObjectDataStructure dataStructure)
        {
            var gymObject = _factory.CreateGymObject(dataStructure);
            return _repository.Create(gymObject);
        }

        public Task<ObjectId> Update(UpdateGymObjectDataStructure dataStructure)
        {
            var gymObject = GetOrThrow(dataStructure.Id);
            gymObject.Update(dataStructure);
            return _repository.Update(dataStructure.Id, gymObject);
        }

        public Task<ObjectId> Delete(ObjectId id)
        {
            var gymObject = GetOrThrow(id);
            return _repository.Remove(gymObject);
        }

        private GymObject GetOrThrow(ObjectId id)
        { 
            return _repository.Get(id) ?? throw new ApplicationException("GymObject not found");
        }
    }
}
