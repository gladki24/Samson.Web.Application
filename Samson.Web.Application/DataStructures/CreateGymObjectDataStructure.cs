using System.Collections.Generic;

namespace Samson.Web.Application.DataStructures
{
    /// <summary>
    /// Data structure to create new gym object
    /// </summary>
    public class CreateGymObjectDataStructure
    {
        public string Name { get; set; }
        public CovidConfigurationDataStructure CovidConfiguration { get; set; }
        public IEnumerable<RoomConfigurationDataStructure> Rooms { get; set; }
    }
}
