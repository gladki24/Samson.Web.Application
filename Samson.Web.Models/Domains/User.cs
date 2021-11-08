using MongoDB.Bson;
using Samson.Web.Application.Infrastructure;
using Samson.Web.Application.Models.DataStructures.User;

namespace Samson.Web.Application.Models.Domains
{
    /// <summary>
    /// User domain to represent application user.
    /// </summary>
    public class User : IAggregateRoot
    {
        public ObjectId Id { get; private set; }
        public string Login { get; private set; }
        public string Password { get; private set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="id">Key</param>
        /// <param name="dataStructure">Data structure to create User</param>
        public User(ObjectId id, CreateUserDataStructure dataStructure)
        {
            Id = id;
            Login = dataStructure.Login;
            Password = dataStructure.Password;
        }

        /// <summary>
        /// Empty constructor.
        /// </summary>
        public User()
        {

        }

        /// <summary>
        /// Update User.
        /// </summary>
        /// <param name="dataStructure">Data structure to update User</param>
        public void Update(UpdateUserDataStructure dataStructure)
        {
            Login = dataStructure.Login;
            Password = dataStructure.Password;
        }
    }
}
