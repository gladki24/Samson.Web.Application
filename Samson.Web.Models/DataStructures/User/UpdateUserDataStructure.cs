using MongoDB.Bson;

namespace Samson.Web.Application.Models.DataStructures.User
{
    /// <summary>
    /// Data structure to update User.
    /// </summary>
    public class UpdateUserDataStructure
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
