using MediatR;
using MongoDB.Bson;

namespace Samson.Web.Application.Commands.User.PersonalTrainer
{
    /// <summary>
    /// Command to update User.
    /// </summary>
    public class UpdatePersonalTrainerCommand : IRequest<ObjectId>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PupilGroupId { get; set; }
    }
}
