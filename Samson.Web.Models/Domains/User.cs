using MongoDB.Bson;
using Samson.Web.Application.Infrastructure;
using Samson.Web.Application.Models.DataStructures.User;

namespace Samson.Web.Application.Models.Domains
{
    /// <summary>
    /// User domain to represent application user.
    /// </summary>
    public class User : IAggregate
    {
        public ObjectId Id { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Login { get; private set; }
        public string Password { get; private set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="id">Key</param>
        /// <param name="password">Hashed password</param>
        /// <param name="dataStructure">Data structure to create User</param>
        protected User(ObjectId id, string password, CreateUserDataStructure dataStructure)
        {
            Id = id;
            Name = dataStructure.Name;
            Surname = dataStructure.Surname;
            Login = dataStructure.Login;
            Password = password;
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
            Name = dataStructure.Name;
            Surname = dataStructure.Surname;
        }
    }
}
