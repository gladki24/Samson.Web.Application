using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Samson.Web.Application.Infrastructure.Attributes;
using Samson.Web.Application.Models.Dtos.GymObject;
using Samson.Web.Application.Queries.GymObject;
using Samson.Web.Application.ReadModels.Interfaces;

namespace Samson.Web.Application.QueryHandlers.GymObject
{
    /// <summary>
    /// Get GymObject by id query handler.
    /// </summary>
    [QueryHandler]
    public class GetGymObjectByIdQueryHandler : IRequestHandler<GymObjectQuery, GymObjectDto>
    {
        private readonly IGymObjectReadModel _readModel;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="readModel">Read model to read GymObjectDto by id from collection.</param>
        public GetGymObjectByIdQueryHandler(IGymObjectReadModel readModel)
        {
            _readModel = readModel ?? throw new ArgumentNullException(nameof(readModel));
        }

        /// <summary>
        /// Handle GymObjectQuery query.
        /// </summary>
        /// <param name="request">Query</param>
        /// <param name="cancellationToken">Cancellation notification</param>
        /// <returns>DTO</returns>
        public Task<GymObjectDto> Handle(GymObjectQuery request, CancellationToken cancellationToken)
        {
            return _readModel.GetById(request.Id);
        }
    }
}
