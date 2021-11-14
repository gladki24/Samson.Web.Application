using MongoDB.Bson;

namespace Samson.Web.Application.Models.DataStructures.User.PersonalTrainer
{
    /// <summary>
    /// Data structure to create new PersonalTrainer.
    /// </summary>
    public class CreatePersonalTrainerDataStructure : CreateUserDataStructure
    {
        public ObjectId? PupilGroupId { get; set; }
    }
}
