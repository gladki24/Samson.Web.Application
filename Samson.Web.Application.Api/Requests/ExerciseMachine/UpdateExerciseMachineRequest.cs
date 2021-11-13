namespace Samson.Web.Application.Api.Requests.ExerciseMachine
{
    /// <summary>
    /// Request to update ExerciseMachine.
    /// </summary>
    public class UpdateExerciseMachineRequest
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public string LocalizationGymObjectId { get; set; }
    }
}
