using MongoDB.Bson;

namespace Samson.Web.Application.Models.DataStructures.User
{
    /// <summary>
    /// Data structure to create User.
    /// </summary>
    public class CreateUserDataStructure
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
