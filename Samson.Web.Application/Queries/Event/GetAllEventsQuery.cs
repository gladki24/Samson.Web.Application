using MediatR;
using System.Collections.Generic;

namespace Samson.Web.Application.Queries.Event
{
    /// <summary>
    /// Query to get all events
    /// </summary>
    public class GetAllEventsQuery : IRequest<List<object>>
    {
    }
}
