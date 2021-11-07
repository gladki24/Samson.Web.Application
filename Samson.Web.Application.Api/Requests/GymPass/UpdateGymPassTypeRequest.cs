namespace Samson.Web.Application.Api.Requests.GymPass
{
    /// <summary>
    /// Request to update GymPassType
    /// </summary>
    public class UpdateGymPassTypeRequest
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Duration { get; set; }
    }
}
