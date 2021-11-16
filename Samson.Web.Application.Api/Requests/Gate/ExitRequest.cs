namespace Samson.Web.Application.Api.Requests.Gate
{
    /// <summary>
    /// Request to inform about client exit from gym object.
    /// </summary>
    public class ExitRequest
    {
        public string GymObjectId { get; set; }
        public string ClientId { get; set; }
    }
}
