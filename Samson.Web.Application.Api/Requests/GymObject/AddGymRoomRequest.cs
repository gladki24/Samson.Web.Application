using Samson.Web.Application.Infrastructure.ViewModels;

namespace Samson.Web.Application.Api.Requests.GymObject
{
    /// <summary>
    /// Request to add GymRoom to GymObject.
    /// </summary>
    public class AddGymRoomRequest
    {
        public string GymObjectId { get; set; }
        public string Name { get; set; }
        public DimensionViewModel Dimensions { get; set; }
    }
}
