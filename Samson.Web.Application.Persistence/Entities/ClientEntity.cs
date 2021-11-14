namespace Samson.Web.Application.Persistence.Entities
{
    /// <summary>
    /// Entity of Client.
    /// </summary>
    public class ClientEntity : UserEntity
    {
        public SubscriptionEntity Subscription { get; set; }
    }
}
