using Samson.Web.Application.Infrastructure.ViewModels;

namespace Samson.Web.Application.Api.Requests.GymObject
{
    /// <summary>
    /// Request to modify room configuration of gym object
    /// </summary>
    public class RoomConfigurationRequest
    {
        public string Name { get; set; }
        public DimensionViewModel Dimensions { get; set; }
    }
}
