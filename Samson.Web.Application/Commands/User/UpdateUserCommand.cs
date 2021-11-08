using MediatR;
using MongoDB.Bson;

namespace Samson.Web.Application.Commands.User
{
    /// <summary>
    /// Command to update User.
    /// </summary>
    public class UpdateUserCommand : IRequest<ObjectId>
    {
        public string Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
