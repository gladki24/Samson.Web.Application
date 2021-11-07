using System.Collections.Generic;
using MediatR;
using Samson.Web.Application.Models.Dtos.GymObject;

namespace Samson.Web.Application.Queries.GymObject
{
    /// <summary>
    /// Query to get all gym objects
    /// </summary>
    public class AllGymObjectQuery : IRequest<List<GymObjectDto>>
    {
    }
}
