using MediatR;
using Samson.Web.Application.Models.Dtos.GymObject;
using Samson.Web.Application.Queries.GymObject;
using System.Threading;
using System.Threading.Tasks;
using Samson.Web.Application.Infrastructure.Attributes;
using Samson.Web.Application.ReadModels.Interfaces;

namespace Samson.Web.Application.QueryHandlers
{
    /// <summary>
    /// Get gym object by id query handler
    /// </summary>
    [QueryHandler]
    public class GetGymObjectByIdQueryHandler : IRequestHandler<GymObjectQuery, GymObjectDto>
    {
        private readonly IGymObjectReadModel _readModel;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="readModel">Read model to read gym object dtos from collection</param>
        public GetGymObjectByIdQueryHandler(IGymObjectReadModel readModel)
        {
            _readModel = readModel;
        }

        /// <summary>
        /// Handle GymObjectQuery
        /// </summary>
        /// <param name="request">query</param>
        /// <param name="cancellationToken">cancellation notification</param>
        /// <returns>DTO</returns>
        public Task<GymObjectDto> Handle(GymObjectQuery request, CancellationToken cancellationToken)
        {
            return _readModel.GetById(request.Id);
        }
    }
}
