using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MongoDB.Bson;
using Samson.Web.Application.Commands.ExerciseMachine;
using Samson.Web.Application.Infrastructure.Attributes;
using Samson.Web.Application.Models.DataStructures.ExerciseMachine;
using Samson.Web.Application.Services.Interfaces;

namespace Samson.Web.Application.CommandHandlers.ExerciseMachine
{
    /// <summary>
    /// CreateExerciseMachine command handler.
    /// </summary>
    [CommandHandler]
    public class CreateExerciseMachineCommandHandler : IRequestHandler<CreateExerciseMachineCommand, ObjectId>
    {
        private readonly IExerciseMachineService _service;
        private readonly IMapper _mapper;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="service">Service to manage ExerciseMachine domain</param>
        /// <param name="mapper">Mapper to map between models</param>
        public CreateExerciseMachineCommandHandler(IExerciseMachineService service, IMapper mapper)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Handle CreateExerciseMachine command.
        /// </summary>
        /// <param name="request">Command</param>
        /// <param name="cancellationToken">Cancellation notification</param>
        /// <returns>Created exercise machine id</returns>
        public Task<ObjectId> Handle(CreateExerciseMachineCommand request, CancellationToken cancellationToken)
        {
            var dataStructure = _mapper.Map<CreateExerciseMachineCommand, CreateExerciseMachineDataStructure>(request);
            return _service.Create(dataStructure);
        }
    }
}
