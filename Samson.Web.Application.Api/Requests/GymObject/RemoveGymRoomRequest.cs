namespace Samson.Web.Application.Api.Requests.GymObject
{
    /// <summary>
    /// Request to remove GymRoom
    /// </summary>
    public class RemoveGymRoomRequest
    {
        public string GymObjectId { get; set; }
        public string GymRoomId { get; set; }
    }
}
