using System;
using MongoDB.Bson;

namespace Samson.Web.Application.Models.Dtos.GymObject
{
    /// <summary>
    /// GymRoomDetails data transfer object.
    /// </summary>
    public class GymRoomDetailsDto
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public Tuple<int, int> Dimensions { get; set; }
        public GymObjectDto GymObject { get; set; }
    }
}
