using MediatR;
using MongoDB.Bson;

namespace Samson.Web.Application.Commands.User
{
    /// <summary>
    /// Command to delete User.
    /// </summary>
    public class DeleteUserCommand : IRequest<ObjectId>
    {
        public string Id { get; set; }
        public string Password { get; set; }
    }
}
