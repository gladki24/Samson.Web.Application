using System.Collections.Generic;

namespace Samson.Web.Application.Api.Requests.GymObject
{
    public class CreateGymObjectRequest
    {
        public string Name { get; set; }
        public CovidConfigurationRequest CovidConfiguration { get; set; }
        public IEnumerable<RoomConfigurationRequest> Rooms { get; set; }
    }
}
