using MongoDB.Bson;

namespace Samson.Web.Application.Models.Dtos.User
{
    /// <summary>
    /// User data transfer object.
    /// </summary>
    public class UserDto
    {
        public ObjectId Id { get; set; }
        public string Login { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="id">Key</param>
        /// <param name="login">Username</param>
        public UserDto(ObjectId id, string login)
        {
            Id = id;
            Login = login;
        }

        /// <summary>
        /// Empty constructor
        /// </summary>
        public UserDto()
        {
        }
    }
}
