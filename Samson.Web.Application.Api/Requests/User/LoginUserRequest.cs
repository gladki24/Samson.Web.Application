namespace Samson.Web.Application.Api.Requests.User
{
    /// <summary>
    /// Request to login User.
    /// </summary>
    public class LoginUserRequest
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
