using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Samson.Web.Application.Infrastructure.Attributes;
using Samson.Web.Application.Models.Dtos;
using Samson.Web.Application.Models.Dtos.GymPass;
using Samson.Web.Application.Queries;
using Samson.Web.Application.Queries.GymPass;
using Samson.Web.Application.ReadModels.Interfaces;

namespace Samson.Web.Application.QueryHandlers
{
    [QueryHandler]
    public class GymPassTypesQueryHandler : IRequestHandler<GetAllGymPassTypesQuery, List<GymPassTypeDto>>
    {
        /// <summary>
        /// Read model to get list of gym pass types
        /// </summary>
        private readonly IGymPassReadModel _readModel;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="readModel">Read model to get list of gym pass types</param>
        public GymPassTypesQueryHandler(IGymPassReadModel readModel)
        {
            _readModel = readModel;
        }

        /// <summary>
        /// Handle gym pass types query
        /// </summary>
        /// <param name="query">Query to handle</param>
        /// <param name="cancellationToken">Propagate information about cancellation</param>
        /// <returns>List of gym pass types</returns>
        public Task<List<GymPassTypeDto>> Handle(GetAllGymPassTypesQuery query, CancellationToken cancellationToken)
        {
            return _readModel.GetAll();
        }
    }
}