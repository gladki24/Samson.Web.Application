using System.Collections.Generic;
using MediatR;
using Samson.Web.Application.Models.Dtos.GymPass;

namespace Samson.Web.Application.Queries.GymPass
{
    /// <summary>
    /// Query to get all GymPassType dtos.
    /// </summary>
    public class GetAllGymPassTypesQuery : IRequest<List<GymPassTypeDto>>
    {
    }
}
