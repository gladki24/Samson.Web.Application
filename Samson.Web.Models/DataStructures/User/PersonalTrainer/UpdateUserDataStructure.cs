using MongoDB.Bson;

namespace Samson.Web.Application.Models.DataStructures.User.PersonalTrainer
{
    /// <summary>
    /// Data structure to update PersonalTrainer.
    /// </summary>
    public class UpdatePersonalTrainerDataStructure : UpdateUserDataStructure
    {
        public ObjectId? PupilsGroupId { get; private set; }
    }
}
