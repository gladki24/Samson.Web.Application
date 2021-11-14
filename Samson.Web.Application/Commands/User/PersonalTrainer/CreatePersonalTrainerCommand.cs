using MediatR;
using MongoDB.Bson;

namespace Samson.Web.Application.Commands.User.PersonalTrainer
{
    /// <summary>
    /// Command to create User.
    /// </summary>
    public class CreatePersonalTrainerCommand : IRequest<ObjectId>
    {
        public string Login { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string PupilsGroupId { get; set; }
    }
}
