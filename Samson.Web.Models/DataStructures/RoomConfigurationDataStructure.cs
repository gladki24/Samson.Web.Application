using System;

namespace Samson.Web.Application.Models.DataStructures
{
    public class RoomConfigurationDataStructure
    {
        public string Name { get; set; }
        public Tuple<int, int> Dimensions { get; set; }
    }
}
