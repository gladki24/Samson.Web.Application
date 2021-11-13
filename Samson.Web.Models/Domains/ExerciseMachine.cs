using System.Runtime.InteropServices;
using MongoDB.Bson;
using Samson.Web.Application.Infrastructure;
using Samson.Web.Application.Models.DataStructures.ExerciseMachine;
using Samson.Web.Application.Models.Enums;

namespace Samson.Web.Application.Models.Domains
{
    /// <summary>
    /// Represent ExerciseMachine
    /// </summary>
    public class ExerciseMachine : IAggregateRoot
    {
        public ObjectId Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public MachineType Type { get; set; }
        public ObjectId LocalizationGymObjectId { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="id">Key</param>
        /// <param name="dataStructure">Data structure to create ExerciseMachine</param>
        public ExerciseMachine(ObjectId id, CreateExerciseMachineDataStructure dataStructure)
        {
            Id = id;
            Code = dataStructure.Code;
            Name = dataStructure.Name;
            Type = dataStructure.Type;
            LocalizationGymObjectId = dataStructure.LocalizationGymObjectId;
        }

        /// <summary>
        /// Update ExerciseMachine domain.
        /// </summary>
        /// <param name="dataStructure">Data to update ExerciseMachine</param>
        public void Update(UpdateExerciseMachineDataStructure dataStructure)
        {
            Code = dataStructure.Code;
            Name = dataStructure.Name;
            Type = dataStructure.Type;
            LocalizationGymObjectId = dataStructure.LocalizationGymObjectId;
        }
    }
}
