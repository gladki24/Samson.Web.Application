using MongoDB.Bson;

namespace Samson.Web.Application.Persistence.Entities
{
    /// <summary>
    /// Entity of PersonalTrainer
    /// </summary>
    public class PersonalTrainerEntity : UserEntity
    {
        public ObjectId? PupilsGroupId { get; set; }
    }
}
