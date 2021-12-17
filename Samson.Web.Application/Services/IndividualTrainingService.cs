using System;
using System.Threading.Tasks;
using MongoDB.Bson;
using Samson.Web.Application.Factories.Interfaces;
using Samson.Web.Application.Infrastructure.Attributes;
using Samson.Web.Application.Infrastructure.Exceptions;
using Samson.Web.Application.Infrastructure.Repository;
using Samson.Web.Application.Models.DataStructures.IndividualTraining;
using Samson.Web.Application.Models.Domains;
using Samson.Web.Application.Resources;
using Samson.Web.Application.Services.Interfaces;

namespace Samson.Web.Application.Services
{
    /// <summary>
    /// Services to work with IndividualTraining model.
    /// </summary>
    [Service]
    public class IndividualTrainingService : IIndividualTrainingService
    {
        private readonly IIndividualTrainingFactory _factory;
        private readonly IRepository<IndividualTraining> _repository;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="factory">Factory to create new IndividualTraining</param>
        /// <param name="repository">Repository to manage IndividualTraining entity</param>
        public IndividualTrainingService(IIndividualTrainingFactory factory, IRepository<IndividualTraining> repository)
        {
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        /// <summary>
        /// Create IndividualTraining aggregate.
        /// </summary>
        /// <param name="dataStructure">Data to create new IndividualTraining</param>
        /// <returns>Created IndividualTraining Id</returns>
        public Task<ObjectId> Create(CreateIndividualTrainingDataStructure dataStructure)
        {
            var training = _factory.Create(dataStructure);
            return _repository.Create(training);
        }

        /// <summary>
        /// Update IndividualTraining aggregate.
        /// </summary>
        /// <param name="dataStructure">Data to update IndividualTraining</param>
        /// <returns>Updated IndividualTraining Id</returns>
        public Task<ObjectId> Update(UpdateIndividualTrainingDataStructure dataStructure)
        {
            var training = GetOrThrow(dataStructure.IndividualTrainingId);
            training.Update(dataStructure);
            return _repository.Update(dataStructure.IndividualTrainingId, training);
        }

        /// <summary>
        /// Cancel IndividualTraining aggregate.
        /// </summary>
        /// <param name="dataStructure">Data to cancel IndividualTraining</param>
        /// <returns>Cancelled IndividualTraining Id</returns>
        public Task<ObjectId> Cancel(CancelIndividualTrainingDataStructure dataStructure)
        {
            var training = GetOrThrow(dataStructure.IndividualTrainingId);
            training.Cancel();
            return _repository.Update(dataStructure.IndividualTrainingId, training);
        }

        /// <summary>
        /// Confirm pending IndividualTraining.
        /// </summary>
        /// <param name="dataStructure">Data to confirm pending IndividualTraining</param>
        /// <returns>Confirmed IndividualTraining Id</returns>
        public Task<ObjectId> Confirm(ConfirmIndividualTrainingDataStructure dataStructure)
        {
            var training = GetOrThrow(dataStructure.IndividualTrainingId);
            training.Confirm();
            return _repository.Update(dataStructure.IndividualTrainingId, training);
        }

        /// <summary>
        /// Enroll Client in IndividualTraining.
        /// </summary>
        /// <param name="dataStructure">Data to enroll client in IndividualTraining</param>
        /// <returns>IndividualTraining</returns>
        public Task<ObjectId> Enroll(EnrollInIndividualTrainingDataStructure dataStructure)
        {
            var training = GetOrThrow(dataStructure.IndividualTrainingId);
            training.Enroll(dataStructure.ClientId);
            return _repository.Update(dataStructure.IndividualTrainingId, training);
        }

        private IndividualTraining GetOrThrow(ObjectId id)
        {
            return _repository.Get(id) ?? throw new BusinessLogicException(ApplicationMessage.IndividualTrainingNotFound);
        }
    }
}
