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
    /// Get GymRoomDetails by id query handler.
    /// </summary>
    [QueryHandler]
    public class GetGymRoomByIdQueryHandler : IRequestHandler<GetGymRoomByIdQuery, GymRoomDetailsDto>
    {
        private readonly IGymObjectReadModel _readModel;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="readModel">Read model to read GymRoom by id from collection</param>
        public GetGymRoomByIdQueryHandler(IGymObjectReadModel readModel)
        {
            _readModel = readModel ?? throw new ArgumentNullException(nameof(readModel));
        }

        /// <summary>
        /// Handle GetGymRoomByIdQuery query.
        /// </summary>
        /// <param name="request">Query</param>
        /// <param name="cancellationToken">Cancellation notifications</param>
        /// <returns></returns>
        public Task<GymRoomDetailsDto> Handle(GetGymRoomByIdQuery request, CancellationToken cancellationToken)
            => _readModel.GetRoomById(request.Id);
    }
}
