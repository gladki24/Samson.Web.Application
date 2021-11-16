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
using Samson.Web.Application.Services.Interfaces;

namespace Samson.Web.Application.Services
{
    [Service]
    public class GateService : IGateService
    {
        private readonly IEntranceFactory _entranceFactory;
        private readonly IClientRepository _clientRepository;
        private readonly IRepository<GymObject> _gymObjectRepository;
        private readonly IEntranceRepository _entranceRepository;

        public GateService(IClientRepository clientRepository, IRepository<GymObject> gymObjectRepository, IEntranceRepository entranceRepository, IEntranceFactory entranceFactory)
        {
            _clientRepository = clientRepository ?? throw new ArgumentNullException(nameof(clientRepository));
            _gymObjectRepository = gymObjectRepository ?? throw new ArgumentNullException(nameof(gymObjectRepository));
            _entranceRepository = entranceRepository ?? throw new ArgumentNullException(nameof(entranceRepository));
            _entranceFactory = entranceFactory ?? throw new ArgumentNullException(nameof(entranceFactory));
        }

        public Task<EntryValidationViewModel> ValidEntrance(EntryDataStructure dataStructure)
        {
            return Task.FromResult(ValidateEntrance(dataStructure));
        }

        public Task<ObjectId> Entry(EntryDataStructure dataStructure)
        {
            var validation = ValidateEntrance(dataStructure);

            if (!validation.HasValidPass)
                throw new BusinessLogicException("The customer does not have a valid subscription.");
            if (validation.IsGymFull)
                throw new BusinessLogicException("The gym is full now.");


            var entrance = _entranceFactory.Create(dataStructure);
            return _entranceRepository.Create(entrance);
        }

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
                throw new BusinessLogicException("Client not found.");

            return client;
        }

        private GymObject GetGymObjectOrThrow(ObjectId gymObjectId)
        {
            var gymObject = _gymObjectRepository.Get(gymObjectId);

            if (gymObject == null)
                throw new BusinessLogicException("Gym object not found.");

            return gymObject;
        }
    }
}
