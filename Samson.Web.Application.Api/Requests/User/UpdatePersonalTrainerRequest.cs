namespace Samson.Web.Application.Api.Requests.User
{
    /// <summary>
    /// Request to update PersonalTrainer.
    /// </summary>
    public class UpdatePersonalTrainerRequest : UpdateUserRequest
    {
        public string PupilGroupId { get; set; }
    }
}
