using MediatR;
using MongoDB.Bson;

namespace Samson.Web.Application.Commands.User.Client
{
    /// <summary>
    /// Command to delete Client.
    /// </summary>
    public class DeleteClientCommand : IRequest<ObjectId>
    {
        public string Id { get; set; }
        public string Password { get; set; }
    }
}
