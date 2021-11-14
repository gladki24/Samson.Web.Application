using MongoDB.Bson;

namespace Samson.Web.Application.Models.DataStructures.Event
{
    /// <summary>
    /// Data structure to client resign
    /// </summary>
    public class ResignEventDataStructure
    {
        public ObjectId ClientId { get; set; }
        public ObjectId EventId { get; set; }
    }
}
