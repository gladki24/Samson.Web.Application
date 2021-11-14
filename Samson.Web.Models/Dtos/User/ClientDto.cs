using Samson.Web.Application.Models.Dtos.Subscription;

namespace Samson.Web.Application.Models.Dtos.User
{
    /// <summary>
    /// Client data transfer object.
    /// </summary>
    public class ClientDto : UserDto
    {
        public SubscriptionDto Subscription { get; set; }
    }
}
