using System.Collections.Generic;
using MongoDB.Bson;

namespace Samson.Web.Application.Models.Dtos.User
{
    /// <summary>
    /// User data transfer object.
    /// </summary>
    public class UserDto
    {
        public ObjectId Id { get; set; }
        public string Password { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public IList<string> Roles { get; set; }
    }
}
