using MongoDB.Bson;

namespace Samson.Web.Application.Models.Dtos.GymObject
{
    public class CovidConfigurationDto
    {
        public ObjectId Id { get; set; }
        public decimal PersonFactorPerMeter { get; set; }
        public bool IsActive { get; set; }
    }
}
