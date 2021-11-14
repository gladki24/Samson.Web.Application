using MediatR;

namespace Samson.Web.Application.Commands.User.Client
{
    /// <summary>
    /// Command to extend Client pass.
    /// </summary>
    public class ExtendClientPassCommand : IRequest<Unit>
    {
        public string ClientId { get; set; }
        public string GymPassTypeId { get; set; }
    }
}
