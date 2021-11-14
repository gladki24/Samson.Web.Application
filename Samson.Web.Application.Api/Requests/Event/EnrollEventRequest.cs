namespace Samson.Web.Application.Api.Requests.Event
{
    /// <summary>
    /// Enroll for the event.
    /// </summary>
    public class EnrollEventRequest
    {
        public string ClientId { get; set; }
        public string EventId { get; set; }
    }
}
