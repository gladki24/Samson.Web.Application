using System.Collections.Generic;

namespace Samson.Web.Application.Api.Requests.GymObject
{
    /// <summary>
    /// Request to create GymObject model
    /// </summary>
    public class CreateGymObjectRequest
    {
        public string Name { get; set; }
        public CovidConfigurationRequest CovidConfiguration { get; set; }
        public IEnumerable<RoomConfigurationRequest> Rooms { get; set; }
    }
}
