using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace Samson.Web.Application.Models.DataStructures.User
{
    /// <summary>
    /// Data structure to create User.
    /// </summary>
    public class CreateUserDataStructure
    {
        public ObjectId Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
