using System.Collections.Generic;
using MongoDB.Bson;

namespace Samson.Web.Application.DataStructures
{
    /// <summary>
    /// Data structure to update existing gym object
    /// </summary>
    public class UpdateGymObjectDataStructure
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public CovidConfigurationDataStructure CovidConfiguration { get; set; }
        public IEnumerable<RoomConfigurationDataStructure> Rooms { get; set; }
    }
}
