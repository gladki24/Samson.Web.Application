using System.Collections.Generic;
using MediatR;
using Samson.Web.Application.Models.Dtos.GymObject;

namespace Samson.Web.Application.Queries.GymObject
{
    /// <summary>
    /// Query to get all GymRoom dtos.
    /// </summary>
    public class GetAllGymRoomQuery : IRequest<List<GymRoomDetailsDto>>
    {
    }
}
