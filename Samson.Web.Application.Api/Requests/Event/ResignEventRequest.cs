namespace Samson.Web.Application.Api.Requests.Event
{
    /// <summary>
    /// Resign from participation in the event request.
    /// </summary>
    public class ResignEventRequest
    {
        public string ClientId { get; set; }
        public string EventId { get; set; }
    }
}
