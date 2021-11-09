using System;
using MongoDB.Bson;

namespace Samson.Web.Application.Models.DataStructures.GymObject
{
    /// <summary>
    /// Data structure to add GymRoom to GymObject.
    /// </summary>
    public class AddGymRoomDataStructure
    {
        public ObjectId GymObjectId { get; set; }
        public string Name { get; set; }
        public Tuple<int, int> Dimensions { get; set; }
    }
}
