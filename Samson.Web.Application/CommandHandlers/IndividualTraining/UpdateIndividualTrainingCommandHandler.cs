using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MongoDB.Bson;
using Samson.Web.Application.Commands.IndividualTraining;
using Samson.Web.Application.Infrastructure.Attributes;
using Samson.Web.Application.Models.DataStructures.IndividualTraining;
using Samson.Web.Application.Services.Interfaces;

namespace Samson.Web.Application.CommandHandlers.IndividualTraining
{
    /// <summary>
    /// UpdateIndividualTrainingCommand command handler.
    /// </summary>
    [CommandHandler]
    public class UpdateIndividualTrainingCommandHandler : IRequestHandler<UpdateIndividualTrainingCommand, ObjectId>
    {
        private readonly IIndividualTrainingService _service;
        private readonly IMapper _mapper;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="service">Service to manage GymPassType domain</param>
        /// <param name="mapper">Mapper to map between models</param>
        public UpdateIndividualTrainingCommandHandler(IIndividualTrainingService service, IMapper mapper)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Handle UpdateIndividualTrainingCommand command.
        /// </summary>
        /// <param name="request">Command</param>
        /// <param name="cancellationToken">Cancellation notification</param>
        /// <returns>Id of updated training</returns>
        public Task<ObjectId> Handle(UpdateIndividualTrainingCommand request, CancellationToken cancellationToken)
        {
            var dataStructure =
                _mapper.Map<UpdateIndividualTrainingCommand, UpdateIndividualTrainingDataStructure>(request);
            return _service.Update(dataStructure);
        }
    }
}
