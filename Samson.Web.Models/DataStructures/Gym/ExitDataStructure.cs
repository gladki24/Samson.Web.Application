using MongoDB.Bson;

namespace Samson.Web.Application.Models.DataStructures.Gym
{
    /// <summary>
    /// Data structure to information about client exit.
    /// </summary>
    public class ExitDataStructure
    {
        public ObjectId GymObjectId { get; set; }
        public ObjectId ClientId { get; set; }
    }
}
