using System;
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
    /// Get IndividualTraining by Id query handler
    /// </summary>
    [QueryHandler]
    public class
        GetIndividualTrainingByIdQueryHandler : IRequestHandler<GetIndividualTrainingByIdQuery, IndividualTrainingDto>
    {
        private readonly IIndividualTrainingReadModel _readModel;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="readModel">Read model to read IndividualTrainingDto by id from collection</param>
        public GetIndividualTrainingByIdQueryHandler(IIndividualTrainingReadModel readModel)
        {
            _readModel = readModel ?? throw new ArgumentNullException(nameof(readModel));
        }

        public Task<IndividualTrainingDto> Handle(GetIndividualTrainingByIdQuery request, CancellationToken cancellationToken)
            => _readModel.GetById(request.Id);
    }
}
