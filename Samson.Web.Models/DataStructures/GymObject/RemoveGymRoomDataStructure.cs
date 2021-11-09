using MongoDB.Bson;

namespace Samson.Web.Application.Models.DataStructures.GymObject
{
    /// <summary>
    /// Data structure to remove GymRoom from GymObject.
    /// </summary>
    public class RemoveGymRoomDataStructure
    {
        public ObjectId GymObjectId { get; set; }
        public ObjectId GymRoomId { get; set; }
    }
}
