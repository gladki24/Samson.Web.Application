using MongoDB.Bson;
using Samson.Web.Application.Models.Enums;

namespace Samson.Web.Application.Models.DataStructures.ExerciseMachine
{
    /// <summary>
    /// Data structure to create ExerciseMachine.
    /// </summary>
    public class CreateExerciseMachineDataStructure
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public MachineType Type { get; set; }
        public ObjectId LocalizationGymObjectId { get; set; }
    }
}
