using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Samson.Web.Application.Infrastructure.Attributes;
using Samson.Web.Application.Models.Dtos.GymPass;
using Samson.Web.Application.Queries.GymPass;
using Samson.Web.Application.ReadModels.Interfaces;

namespace Samson.Web.Application.QueryHandlers.GymPass
{
    /// <summary>
    /// Query to get GymPassType by id
    /// </summary>
    [QueryHandler]
    public class GymPassTypeByIdQueryHandler : IRequestHandler<GetGymPassTypeByIdQuery, GymPassTypeDto>
    {
        /// <summary>
        /// Read model to get GymPassType by id.
        /// </summary>
        private readonly IGymPassReadModel _readModel;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="readModel">Read model to get GymPassType by id</param>
        public GymPassTypeByIdQueryHandler(IGymPassReadModel readModel)
        {
            _readModel = readModel ?? throw new ArgumentNullException(nameof(readModel));
        }

        /// <summary>
        /// Handle GetGymPassTypeByIdQuery query
        /// </summary>
        /// <param name="request">Query to handle</param>
        /// <param name="cancellationToken">Cancellation notification</param>
        /// <returns>GymPassType DTO</returns>
        public Task<GymPassTypeDto> Handle(GetGymPassTypeByIdQuery request, CancellationToken cancellationToken)
        {
            return _readModel.GetById(request.Id);
        }
    }
}
