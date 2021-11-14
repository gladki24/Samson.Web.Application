using MediatR;
using MongoDB.Bson;

namespace Samson.Web.Application.Commands.User.Client
{
    /// <summary>
    /// Command to register new Client.
    /// </summary>
    public class RegisterClientCommand : IRequest<ObjectId>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
