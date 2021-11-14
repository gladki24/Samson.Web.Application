using MediatR;
using MongoDB.Bson;

namespace Samson.Web.Application.Commands.User.Client
{
    /// <summary>
    /// Command to update Client.
    /// </summary>
    public class UpdateClientCommand : IRequest<ObjectId>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
