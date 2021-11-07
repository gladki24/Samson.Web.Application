using MongoDB.Bson;

namespace Samson.Web.Application.Models.DataStructures.GymObject
{
    /// <summary>
    /// Data structure to update existing GymObject.
    /// </summary>
    public class UpdateGymObjectDataStructure
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public CovidConfigurationDataStructure CovidConfiguration { get; set; }
    }
}
