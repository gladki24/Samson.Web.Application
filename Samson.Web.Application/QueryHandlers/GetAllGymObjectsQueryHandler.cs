using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Samson.Web.Application.Infrastructure.Attributes;
using Samson.Web.Application.Models.Dtos.GymObject;
using Samson.Web.Application.Queries.GymObject;

namespace Samson.Web.Application.QueryHandlers
{
    /// <summary>
    /// Get all gym object query handler
    /// </summary>
    [QueryHandler]
    public class GetAllGymObjectsQueryHandler : IRequestHandler<AllGymObjectQuery, List<GymObjectDto>>
    {
        /// <summary>
        /// Handle AllGymObjectQuery
        /// </summary>
        /// <param name="request">query</param>
        /// <param name="cancellationToken">cancellation notification</param>
        /// <returns>DTO</returns>
        public Task<List<GymObjectDto>> Handle(AllGymObjectQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
