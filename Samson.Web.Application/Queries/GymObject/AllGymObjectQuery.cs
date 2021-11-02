using System.Collections.Generic;
using MediatR;
using Samson.Web.Application.Models.Dtos.GymObject;

namespace Samson.Web.Application.Queries.GymObject
{
    public class AllGymObjectQuery : IRequest<List<GymObjectDto>>
    {
    }
}
