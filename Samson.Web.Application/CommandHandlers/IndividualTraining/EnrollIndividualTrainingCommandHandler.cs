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
    /// EnrollIndividualTrainingCommand command handler.
    /// </summary>
    [CommandHandler]
    public class EnrollIndividualTrainingCommandHandler : IRequestHandler<EnrollIndividualTrainingCommand, ObjectId>
    {
        private readonly IIndividualTrainingService _service;
        private readonly IMapper _mapper;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="service">Service to manage GymPassType domain</param>
        /// <param name="mapper">Mapper to map between models</param>
        public EnrollIndividualTrainingCommandHandler(IIndividualTrainingService service, IMapper mapper)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Handler EnrollIndividualTrainingCommand command.
        /// </summary>
        /// <param name="request">Command</param>
        /// <param name="cancellationToken">Cancellation notification</param>
        /// <returns>Id of training</returns>
        public Task<ObjectId> Handle(EnrollIndividualTrainingCommand request, CancellationToken cancellationToken)
        {
            var dataStructure =
                _mapper.Map<EnrollIndividualTrainingCommand, EnrollInIndividualTrainingDataStructure>(request);
            return _service.Enroll(dataStructure);
        }
    }
}
