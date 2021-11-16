namespace Samson.Web.Application.Api.Requests.Gate
{
    /// <summary>
    /// Request to inform about client entry to gym.
    /// </summary>
    public class EntryRequest
    {
        public string GymObjectId { get; set; }
        public string ClientId { get; set; }
    }
}
