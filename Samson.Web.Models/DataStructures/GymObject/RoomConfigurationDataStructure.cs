using System;

namespace Samson.Web.Application.Models.DataStructures.GymObject
{
    /// <summary>
    /// Data structure to modify RoomConfiguration.
    /// </summary>
    public class RoomConfigurationDataStructure
    {
        public string Name { get; set; }
        public Tuple<int, int> Dimensions { get; set; }
    }
}
