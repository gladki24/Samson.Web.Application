namespace Samson.Web.Application.Api.ViewModels.User
{
    /// <summary>
    /// Client view model.
    /// </summary>
    public class ClientViewModel : UserViewModel
    {
        public SubscriptionViewModel Subscription { get; set; }
    }
}
