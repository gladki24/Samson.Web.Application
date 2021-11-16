using System;
using MongoDB.Bson;
using Samson.Web.Application.Factories.Interfaces;
using Samson.Web.Application.Infrastructure.Attributes;
using Samson.Web.Application.Models.DataStructures.Gym;
using Samson.Web.Application.Models.Domains;

namespace Samson.Web.Application.Factories
{
    [Factory]
    public class EntranceFactory : IEntranceFactory
    {
        public Entrance Create(EntryDataStructure dataStructure)
            => new Entrance(ObjectId.GenerateNewId(), dataStructure, DateTime.Now);
    }
}
