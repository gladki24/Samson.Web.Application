using MediatR;
using Samson.Web.Application.Models;

namespace Samson.Web.Application.Commands.Gate
{
    /// <summary>
    /// Command to valid client entrance to the gym.
    /// </summary>
    public class ValidEntranceCommand : IRequest<EntryValidationViewModel>
    {
        public string GymObjectId { get; set; }
        public string ClientId { get; set; }
    }
}
