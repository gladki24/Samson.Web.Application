using Samson.Web.Application.Api.ViewModels.GymObject;

namespace Samson.Web.Application.Api.ViewModels.ExerciseMachine
{
    /// <summary>
    /// ExerciseMachine model. 
    /// </summary>
    public class ExerciseMachineViewModel
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public GymObjectViewModel LocalizationGymObject { get; set; }
    }
}
