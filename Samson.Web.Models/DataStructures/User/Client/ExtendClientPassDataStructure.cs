using MongoDB.Bson;

namespace Samson.Web.Application.Models.DataStructures.User.Client
{
    /// <summary>
    /// Data structure to extend Client gym pass.
    /// </summary>
    public class ExtendClientPassDataStructure
    {
        public ObjectId ClientId { get; set; }
        public ObjectId GymPassTypeId { get; set; }
    }
}
