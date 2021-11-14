using MongoDB.Bson;

namespace Samson.Web.Application.Models.DataStructures.Event
{
    /// <summary>
    /// Data structure to client event enroll.
    /// </summary>
    public class EnrollEventDataStructure
    {
        public ObjectId ClientId { get; set; }
        public ObjectId EventId { get; set; }
    }
}
