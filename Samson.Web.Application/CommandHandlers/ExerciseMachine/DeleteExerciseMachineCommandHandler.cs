using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MongoDB.Bson;
using Samson.Web.Application.Commands.ExerciseMachine;
using Samson.Web.Application.Infrastructure.Attributes;
using Samson.Web.Application.Services.Interfaces;

namespace Samson.Web.Application.CommandHandlers.ExerciseMachine
{
    /// <summary>
    /// DeleteExerciseMachineCommand command handler.
    /// </summary>
    [CommandHandler]
    public class DeleteExerciseMachineCommandHandler : IRequestHandler<DeleteExerciseMachineCommand, ObjectId>
    {
        private readonly IExerciseMachineService _service;
        private readonly IMapper _mapper;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="service">Service to manage ExerciseMachine domain</param>
        /// <param name="mapper">Mapper to map between models</param>
        public DeleteExerciseMachineCommandHandler(IExerciseMachineService service, IMapper mapper)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Handle DeleteExerciseMachine command.
        /// </summary>
        /// <param name="request">Command</param>
        /// <param name="cancellationToken">Cancellation notification</param>
        /// <returns></returns>
        public Task<ObjectId> Handle(DeleteExerciseMachineCommand request, CancellationToken cancellationToken)
        {
            var id = _mapper.Map<string, ObjectId>(request.Id);
            return _service.Delete(id);
        }
    }
}
