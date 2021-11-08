using MongoDB.Bson;

namespace Samson.Web.Application.Models.DataStructures.User
{
    /// <summary>
    /// Data structure to delete User.
    /// </summary>
    public class DeleteUserDataStructure
    {
        public ObjectId Id { get; set; }
        public string Password { get; set; }
    }
}
