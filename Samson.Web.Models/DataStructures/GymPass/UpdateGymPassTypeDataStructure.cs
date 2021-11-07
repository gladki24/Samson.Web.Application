using MongoDB.Bson;

namespace Samson.Web.Application.Models.DataStructures.GymPass
{
    /// <summary>
    /// Data structure to update existing GymPassType.
    /// </summary>
    public class UpdateGymPassTypeDataStructure
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Duration { get; set; }
    }
}
