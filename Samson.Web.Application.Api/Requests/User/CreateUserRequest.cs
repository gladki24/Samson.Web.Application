namespace Samson.Web.Application.Api.Requests.User
{
    /// <summary>
    /// Request to create user.
    /// </summary>
    public class CreateUserRequest
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
