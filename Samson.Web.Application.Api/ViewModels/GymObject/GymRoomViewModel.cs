using System;

namespace Samson.Web.Application.Api.ViewModels.GymObject
{
    /// <summary>
    /// Gym room view model
    /// </summary>
    public class GymRoomViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Tuple<int, int> Dimensions { get; set; }
    }
}
