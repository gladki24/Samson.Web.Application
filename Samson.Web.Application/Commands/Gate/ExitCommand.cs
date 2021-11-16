using MediatR;

namespace Samson.Web.Application.Commands.Gate
{
    /// <summary>
    /// Request to inform about client exit from gym object.
    /// </summary>
    public class ExitCommand : IRequest<Unit>
    {
        public string GymObjectId { get; set; }
        public string ClientId { get; set; }
    }
}
