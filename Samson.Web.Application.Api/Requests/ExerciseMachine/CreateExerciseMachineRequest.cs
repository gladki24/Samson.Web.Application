namespace Samson.Web.Application.Api.Requests.ExerciseMachine
{
    /// <summary>
    /// Request to create ExerciseMachine.
    /// </summary>
    public class CreateExerciseMachineRequest
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public string LocalizationGymObjectId { get; set; }
    }
}
