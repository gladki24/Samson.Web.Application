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
    public class ExerciseMachine : IAggregate
    {
        public ObjectId Id { get; private set; }
        public string Code { get; private set; }
        public string Name { get; private set; }
        public MachineType Type { get; private set; }
        public ObjectId LocalizationGymObjectId { get; private set; }

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
        /// Empty constructor.
        /// </summary>
        public ExerciseMachine()
        {}

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
