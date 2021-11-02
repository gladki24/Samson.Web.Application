using System;

namespace Samson.Web.Application.Api.Requests.GymObject
{
    public class RoomConfigurationRequest
    {
        public string Name { get; set; }
        public Tuple<int, int> Dimensions { get; set; }
    }
}
