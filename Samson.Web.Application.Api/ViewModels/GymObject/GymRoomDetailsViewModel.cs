using Samson.Web.Application.Infrastructure.ViewModels;

namespace Samson.Web.Application.Api.ViewModels.GymObject
{
    /// <summary>
    /// GymRoomDetails view model
    /// </summary>
    public class GymRoomDetailsViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DimensionViewModel Dimensions { get; set; }
        public GymObjectViewModel GymObject { get; set; }
    }
}
