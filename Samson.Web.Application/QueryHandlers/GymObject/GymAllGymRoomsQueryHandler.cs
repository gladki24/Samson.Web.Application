using System;
using System.Collections.Generic;
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
    /// Get all GetAllGymRoomsQuery query handler.
    /// </summary>
    [QueryHandler]
    public class GymAllGymRoomsQueryHandler : IRequestHandler<GetAllGymRoomQuery, List<GymRoomDetailsDto>>
    {
        private readonly IGymObjectReadModel _readModel;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="readModel">Read model to read GymRoomDetail dtos from collection</param>
        public GymAllGymRoomsQueryHandler(IGymObjectReadModel readModel)
        {
            _readModel = readModel ?? throw new ArgumentNullException(nameof(readModel));
        }

        /// <summary>
        /// Handle GetAllGymRoomsQuery query.
        /// </summary>
        /// <param name="request">Query</param>
        /// <param name="cancellationToken">Cancellation notification</param>
        /// <returns></returns>
        public Task<List<GymRoomDetailsDto>> Handle(GetAllGymRoomQuery request, CancellationToken cancellationToken)
            => _readModel.GetAllRooms();
    }
}
