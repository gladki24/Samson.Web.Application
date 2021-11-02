using System.Collections.Generic;

namespace Samson.Web.Application.Api.Requests.GymObject
{
    public class UpdateGymObjectRequest
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public CovidConfigurationRequest CovidConfiguration { get; set; }
        public IEnumerable<RoomConfigurationRequest> Rooms { get; set; }
    }
}
