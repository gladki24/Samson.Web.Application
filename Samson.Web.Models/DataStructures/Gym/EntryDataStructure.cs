using MongoDB.Bson;

namespace Samson.Web.Application.Models.DataStructures.Gym
{
    /// <summary>
    /// Data structure to inform about attempt to entry gym by client.
    /// </summary>
    public class EntryDataStructure
    {
        public ObjectId GymObjectId { get; set; }
        public ObjectId ClientId { get; set; }
    }
}
