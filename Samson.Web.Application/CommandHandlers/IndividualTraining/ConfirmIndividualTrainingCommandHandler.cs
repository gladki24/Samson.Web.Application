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
    /// ConfirmIndividualTrainingCommand command handler.
    /// </summary>
    [CommandHandler]
    public class ConfirmIndividualTrainingCommandHandler : IRequestHandler<ConfirmIndividualTrainingCommand, ObjectId>
    {
        private readonly IIndividualTrainingService _service;
        private readonly IMapper _mapper;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="service">Service to manage GymPassType domain</param>
        /// <param name="mapper">Mapper to map between models</param>
        public ConfirmIndividualTrainingCommandHandler(IIndividualTrainingService service, IMapper mapper)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Handle ConfirmIndividualTrainingCommand command.
        /// </summary>
        /// <param name="request">Command</param>
        /// <param name="cancellationToken">Cancellation notification</param>
        /// <returns></returns>
        public Task<ObjectId> Handle(ConfirmIndividualTrainingCommand request, CancellationToken cancellationToken)
        {
            var dataStructure = _mapper.Map<ConfirmIndividualTrainingCommand, ConfirmIndividualTrainingDataStructure>(
                request);
            return _service.Confirm(dataStructure);
        }
    }
}
