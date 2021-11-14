using MediatR;

namespace Samson.Web.Application.Commands.Event
{
    /// <summary>
    /// Command to Enroll for the event.
    /// </summary>
    public class EnrollEventCommand : IRequest<Unit>
    {
        public string ClientId { get; set; }
        public string EventId { get; set; }
    }
}
