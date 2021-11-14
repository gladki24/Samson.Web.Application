using MediatR;

namespace Samson.Web.Application.Commands.Event
{
    /// <summary>
    /// Command to Resign from participation in the event.
    /// </summary>
    public class ResignEventCommand : IRequest<Unit>
    {
        public string ClientId { get; set; }
        public string EventId { get; set; }
    }
}
