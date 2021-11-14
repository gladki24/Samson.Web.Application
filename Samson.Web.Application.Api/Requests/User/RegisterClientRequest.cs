namespace Samson.Web.Application.Api.Requests.User
{
    /// <summary>
    /// Request to register new Client.
    /// </summary>
    public class RegisterClientRequest
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
