namespace Samson.Web.Application.Api.Requests.GymPass
{
    /// <summary>
    /// Request to create GymPassType model.
    /// </summary>
    public class CreateGymPassTypeRequest
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Duration { get; set; }
    }
}
