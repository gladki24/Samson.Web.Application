namespace Samson.Web.Application.Api.Requests.User
{
    /// <summary>
    /// Request to create user.
    /// </summary>
    public class CreatePersonalTrainerRequest
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string PupilsGroupId { get; set; }
    }
}
