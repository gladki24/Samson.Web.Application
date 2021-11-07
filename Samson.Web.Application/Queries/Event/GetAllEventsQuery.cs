using MediatR;
using System.Collections.Generic;
using Samson.Web.Application.Models.Dtos.Event;

namespace Samson.Web.Application.Queries.Event
{
    /// <summary>
    /// Query to get all Event dtos.
    /// </summary>
    public class GetAllEventsQuery : IRequest<List<EventDto>>
    {
    }
}
