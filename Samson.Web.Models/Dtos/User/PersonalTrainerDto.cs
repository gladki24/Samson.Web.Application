using MongoDB.Bson;

namespace Samson.Web.Application.Models.Dtos.User
{
    /// <summary>
    /// PersonalTrainer data transfer object.
    /// </summary>
    public class PersonalTrainerDto : UserDto
    {
        public ObjectId? PupilsGroupId { get; set; }
    }
}
