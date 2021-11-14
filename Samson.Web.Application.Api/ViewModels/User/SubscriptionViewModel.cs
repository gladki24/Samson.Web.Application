using MongoDB.Bson;

namespace Samson.Web.Application.Api.ViewModels.User
{
    /// <summary>
    /// Subscription view model.
    /// </summary>
    public class SubscriptionViewModel
    {
        public string Id { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string GymPassTypeId { get; set; }
    }
}
