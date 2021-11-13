using MongoDB.Bson;
using Samson.Web.Application.Models.Dtos.GymObject;
using Samson.Web.Application.Models.Enums;

namespace Samson.Web.Application.Models.Dtos.ExerciseMachine
{
    /// <summary>
    /// ExerciseMachine transfer object.
    /// </summary>
    public class ExerciseMachineDto
    {
        public ObjectId Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public MachineType Type { get; set; }
        public ObjectId LocalizationGymObjectId { get; set; }
        public GymObjectDto LocalizationGymObject { get; set; }
    }
}
