using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Samson.Web.Application.Infrastructure.Attributes;
using Samson.Web.Application.Models.Dtos.IndividualTraining;
using Samson.Web.Application.Queries.IndividualTraining;
using Samson.Web.Application.ReadModels.Interfaces;

namespace Samson.Web.Application.QueryHandlers.IndividualTraining
{
    /// <summary>
    /// Get all IndividualTraining query handler.
    /// </summary>
    [QueryHandler]
    public class GetAllIndividualTrainingQueryHandler : IRequestHandler<GetAllIndividualTrainingQuery, List<IndividualTrainingDto>>
    {
        private readonly IIndividualTrainingReadModel _readModel;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="readModel">Read model to read IndividualTraining dtos from collection</param>
        public GetAllIndividualTrainingQueryHandler(IIndividualTrainingReadModel readModel)
        {
            _readModel = readModel ?? throw new ArgumentNullException(nameof(readModel));
        }

        /// <summary>
        /// Handle GetAllIndividualTrainingQuery.
        /// </summary>
        /// <param name="request">Command</param>
        /// <param name="cancellationToken">Cancellation notification</param>
        /// <returns></returns>
        public Task<List<IndividualTrainingDto>> Handle(GetAllIndividualTrainingQuery request, CancellationToken cancellationToken)
            => _readModel.GetAll();
    }
}
