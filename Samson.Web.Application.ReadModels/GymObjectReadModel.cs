using System;
using System.Collections.Generic;
using MongoDB.Bson;
using Samson.Web.Application.Models.Dtos.GymObject;
using Samson.Web.Application.ReadModels.Interfaces;

namespace Samson.Web.Application.ReadModels
{
    /// <summary>
    /// Default implementation of IGymObjectReadModel
    /// </summary>
    public class GymObjectReadModel : IGymObjectReadModel
    {
        public GymObjectDto GetById(ObjectId id)
        {
            throw new NotImplementedException();
        }

        public List<GymObjectDto> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
