using MediatR;
using MongoDB.Bson;

namespace Samson.Web.Application.Commands.User.PersonalTrainer
{
    /// <summary>
    /// Command to delete PersonalTrainer.
    /// </summary>
    public class DeletePersonalTrainerCommand : IRequest<ObjectId>
    {
        public string Id { get; set; }
        public string Password { get; set; }
    }
}
