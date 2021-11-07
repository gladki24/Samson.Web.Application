using System.Collections.Generic;

namespace Samson.Web.Application.Api.Requests.GymObject
{
    /// <summary>
    /// Request to update gym object
    /// </summary>
    public class UpdateGymObjectRequest
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public CovidConfigurationRequest CovidConfiguration { get; set; }
    }
}
