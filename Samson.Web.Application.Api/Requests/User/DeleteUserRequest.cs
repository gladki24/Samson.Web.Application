namespace Samson.Web.Application.Api.Requests.User
{
    /// <summary>
    /// Request to delete User.
    /// </summary>
    public class DeleteUserRequest
    {
        public string Id { get; set; }
        public string Password { get; set; }
    }
}
