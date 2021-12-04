using System;
using System.Threading.Tasks;
using MongoDB.Bson;
using Samson.Web.Application.Factories.Interfaces;
using Samson.Web.Application.Infrastructure.Attributes;
using Samson.Web.Application.Infrastructure.Exceptions;
using Samson.Web.Application.Infrastructure.Repository;
using Samson.Web.Application.Models.DataStructures.ExerciseMachine;
using Samson.Web.Application.Models.Domains;
using Samson.Web.Application.Resources;
using Samson.Web.Application.Services.Interfaces;

namespace Samson.Web.Application.Services
{
    /// <summary>
    /// Application service to work with ExerciseMachine domain.
    /// </summary>
    [Service]
    public class ExerciseMachineService : IExerciseMachineService
    {
        private readonly IRepository<ExerciseMachine> _repository;
        private readonly IExerciseMachineFactory _factory;

        public ExerciseMachineService(IRepository<ExerciseMachine> repository, IExerciseMachineFactory factory)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        public Task<ObjectId> Create(CreateExerciseMachineDataStructure dataStructure)
        {
            var machine = _factory.Create(dataStructure);
            return _repository.Create(machine);
        }

        public Task<ObjectId> Update(UpdateExerciseMachineDataStructure dataStructure)
        {
            var machine = GetOrThrow(dataStructure.Id);
            machine.Update(dataStructure);
            return _repository.Update(dataStructure.Id, machine);
        }

        public Task<ObjectId> Delete(ObjectId id)
        {
            var machine = GetOrThrow(id);
            return _repository.Remove(machine);
        }

        private ExerciseMachine GetOrThrow(ObjectId id) =>
            _repository.Get(id) ?? throw new BusinessLogicException(ApplicationMessage.ExerciseMachineNotFound);
    }
}
