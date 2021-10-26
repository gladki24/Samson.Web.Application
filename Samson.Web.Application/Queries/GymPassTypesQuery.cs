using System.Collections.Generic;
using MediatR;
using Samson.Web.Application.Models.Dtos;

namespace Samson.Web.Application.Queries
{
    public class GymPassTypesQuery : IRequest<List<GymPassTypeDto>>
    {
    }
}
