using System;
using System.Threading.Tasks;
using MediatR;
using MongoDB.Bson;
using Samson.Web.Application.Factories.Interfaces;
using Samson.Web.Application.Infrastructure.Attributes;
using Samson.Web.Application.Infrastructure.Exceptions;
using Samson.Web.Application.Infrastructure.Repository;
using Samson.Web.Application.Models;
using Samson.Web.Application.Models.DataStructures.Gym;
using Samson.Web.Application.Models.Domains;
using Samson.Web.Application.Persistence.Repositories.Interfaces;
using Samson.Web.Application.Resources;
using Samson.Web.Application.Services.Interfaces;

namespace Samson.Web.Application.Services
{
    /// <summary>
    /// Service to manage gate exit and entrance to gym.
    /// </summary>
    [Service]
    public class GateService : IGateService
    {
        private readonly IEntranceFactory _entranceFactory;
        private readonly IClientRepository _clientRepository;
        private readonly IRepository<GymObject> _gymObjectRepository;
        private readonly IEntranceRepository _entranceRepository;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="clientRepository">Repository to manage gate entity</param>
        /// <param name="gymObjectRepository">Repository to manage gym object entity</param>
        /// <param name="entranceRepository">Repository to manage entrance entity</param>
        /// <param name="entranceFactory">Repository to create Entrance</param>
        public GateService(IClientRepository clientRepository, IRepository<GymObject> gymObjectRepository, IEntranceRepository entranceRepository, IEntranceFactory entranceFactory)
        {
            _clientRepository = clientRepository ?? throw new ArgumentNullException(nameof(clientRepository));
            _gymObjectRepository = gymObjectRepository ?? throw new ArgumentNullException(nameof(gymObjectRepository));
            _entranceRepository = entranceRepository ?? throw new ArgumentNullException(nameof(entranceRepository));
            _entranceFactory = entranceFactory ?? throw new ArgumentNullException(nameof(entranceFactory));
        }

        /// <summary>
        /// Validate attempt to entry to the gym object.
        /// </summary>
        /// <param name="dataStructure">Information entrance attempt</param>
        /// <returns>Return information about entry possibility</returns>
        public Task<EntryValidationViewModel> ValidEntrance(EntryDataStructure dataStructure)
        {
            return Task.FromResult(ValidateEntrance(dataStructure));
        }

        /// <summary>
        /// Inform about client entry to gym.
        /// </summary>
        /// <param name="dataStructure">Information about client entrance</param>
        /// <returns>Entrance aggregate id</returns>
        public Task<ObjectId> Entry(EntryDataStructure dataStructure)
        {
            var validation = ValidateEntrance(dataStructure);

            if (!validation.HasValidPass)
                throw new BusinessLogicException(ApplicationMessage.NotValidSubscription);
            if (validation.IsGymFull)
                throw new BusinessLogicException(ApplicationMessage.GymIsFull);


            var entrance = _entranceFactory.Create(dataStructure);
            return _entranceRepository.Create(entrance);
        }

        /// <summary>
        /// Inform about client exit from gym.
        /// </summary>
        /// <param name="dataStructure">Information about exit</param>
        public Task<Unit> Exit(ExitDataStructure dataStructure)
        {
            var entrances = _entranceRepository.GetAllByGymObjectIdAndClientId(dataStructure.GymObjectId, dataStructure.ClientId);
            entrances.ForEach(entrance => _entranceRepository.Remove(entrance.Id));
            return Task.FromResult(new Unit());
        }

        private EntryValidationViewModel ValidateEntrance(EntryDataStructure dataStructure)
        {
            var client = GetClientOrThrow(dataStructure.ClientId);
            var gymObject = GetGymObjectOrThrow(dataStructure.GymObjectId);

            var maxClientsCountInGymObject = gymObject.CalcMaximumClientsCount();
            var clientsCountInGymObject = _entranceRepository.GetAllByGymObjectId(dataStructure.GymObjectId).Count;
            var isGymFull = clientsCountInGymObject >= maxClientsCountInGymObject;

            var validationResult = new EntryValidationViewModel
            {
                CurrentNumberOfClients = clientsCountInGymObject,
                HasValidPass = client.HasActiveSubscription,
                IsGymFull = isGymFull,
                MaximumNumberOfClients = maxClientsCountInGymObject
            };

            return validationResult;
        }

        private Client GetClientOrThrow(ObjectId clientId)
        {
            var client = _clientRepository.Get(clientId);

            if (client == null)
                throw new BusinessLogicException(ApplicationMessage.ClientNotFound);

            return client;
        }

        private GymObject GetGymObjectOrThrow(ObjectId gymObjectId)
        {
            var gymObject = _gymObjectRepository.Get(gymObjectId);

            if (gymObject == null)
                throw new BusinessLogicException(ApplicationMessage.GymObjectNotFound);

            return gymObject;
        }
    }
}
