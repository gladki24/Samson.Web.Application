namespace Samson.Web.Application.Api.Requests.GymObject
{
    /// <summary>
    /// Request of CovidConfiguration view model
    /// </summary>
    public class CovidConfigurationRequest
    {
        public decimal PersonFactorPerMeter { get; set; }
        public bool IsActive { get; set; }
    }
}
