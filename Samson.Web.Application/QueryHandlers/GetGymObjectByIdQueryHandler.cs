using MediatR;
using Samson.Web.Application.Models.Dtos.GymObject;
using Samson.Web.Application.Queries.GymObject;
using System.Threading;
using System.Threading.Tasks;
using Samson.Web.Application.Infrastructure.Attributes;

namespace Samson.Web.Application.QueryHandlers
{
    /// <summary>
    /// Get gym object by id query handler
    /// </summary>
    [QueryHandler]
    public class GetGymObjectByIdQueryHandler : IRequestHandler<GymObjectQuery, GymObjectDto>
    {
        /// <summary>
        /// Handle GymObjectQuery
        /// </summary>
        /// <param name="request">query</param>
        /// <param name="cancellationToken">cancellation notification</param>
        /// <returns>DTO</returns>
        public Task<GymObjectDto> Handle(GymObjectQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
