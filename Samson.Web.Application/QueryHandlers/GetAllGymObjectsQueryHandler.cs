using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Samson.Web.Application.Infrastructure.Attributes;
using Samson.Web.Application.Models.Dtos.GymObject;
using Samson.Web.Application.Queries.GymObject;
using Samson.Web.Application.ReadModels.Interfaces;

namespace Samson.Web.Application.QueryHandlers
{
    /// <summary>
    /// Get all gym object query handler
    /// </summary>
    [QueryHandler]
    public class GetAllGymObjectsQueryHandler : IRequestHandler<AllGymObjectQuery, List<GymObjectDto>>
    {
        private readonly IGymObjectReadModel _readModel;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="readModel">Read model to read gym object dtos from collection</param>
        public GetAllGymObjectsQueryHandler(IGymObjectReadModel readModel)
        {
            _readModel = readModel ?? throw new ArgumentNullException(nameof(readModel));
        }

        /// <summary>
        /// Handle AllGymObjectQuery
        /// </summary>
        /// <param name="request">query</param>
        /// <param name="cancellationToken">cancellation notification</param>
        /// <returns>DTO</returns>
        public Task<List<GymObjectDto>> Handle(AllGymObjectQuery request, CancellationToken cancellationToken)
        {
            return _readModel.GetAll();
        }
    }
}
