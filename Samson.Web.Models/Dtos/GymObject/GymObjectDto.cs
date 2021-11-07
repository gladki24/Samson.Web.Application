using System.Collections.Generic;
using MongoDB.Bson;

namespace Samson.Web.Application.Models.Dtos.GymObject
{
    /// <summary>
    /// GymObject data transfer object.
    /// </summary>
    public class GymObjectDto
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public CovidConfigurationDto CovidConfiguration { get; set; }
        public IEnumerable<GymRoomDto> Rooms { get; set; }
    }
}
