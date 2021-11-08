using MediatR;

namespace Samson.Web.Application.Commands.User
{
    /// <summary>
    /// Command to login User
    /// </summary>
    public class LoginUserCommand : IRequest<string>
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
