using System;

namespace Samson.Web.Application.DataStructures
{
    public class RoomConfigurationDataStructure
    {
        public string Name { get; set; }
        public Tuple<int, int> Dimensions { get; set; }
    }
}
