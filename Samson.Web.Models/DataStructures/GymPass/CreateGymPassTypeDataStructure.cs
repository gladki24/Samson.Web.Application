using MongoDB.Bson;

namespace Samson.Web.Application.Models.DataStructures.GymPass
{
    /// <summary>
    /// Data structure to create GymPassType.
    /// </summary>
    public class CreateGymPassTypeDataStructure
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Duration { get; set; }
    }
}
