using MediatR;
using MongoDB.Bson;

namespace Samson.Web.Application.Commands.User
{
    /// <summary>
    /// Command to create User.
    /// </summary>
    public class CreateUserCommand : IRequest<ObjectId>
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
