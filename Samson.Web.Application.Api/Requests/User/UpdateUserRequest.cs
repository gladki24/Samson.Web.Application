namespace Samson.Web.Application.Api.Requests.User
{
    /// <summary>
    /// Request to create user.
    /// </summary>
    public class UpdateUserRequest
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
