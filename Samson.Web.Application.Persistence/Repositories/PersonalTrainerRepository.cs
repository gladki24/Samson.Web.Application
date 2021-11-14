﻿using AutoMapper;
using Samson.Web.Application.Infrastructure.Attributes;
using Samson.Web.Application.Infrastructure.Configuration;
using Samson.Web.Application.Models.Domains;
using Samson.Web.Application.Persistence.Entities;
using Samson.Web.Application.Persistence.Repositories.Interfaces;

namespace Samson.Web.Application.Persistence.Repositories
{
    /// <summary>
    /// Repository of PersonalTrainer domain.
    /// </summary>
    [Repository]
    public class PersonalTrainerRepository : UserRepository<PersonalTrainer, PersonalTrainerEntity>, IPersonalTrainerRepository
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="databaseConfiguration">Configuration to connect database</param>
        /// <param name="mapper">Mapper to map between models</param>
        public PersonalTrainerRepository(IDatabaseConfiguration databaseConfiguration, IMapper mapper)
            : base(databaseConfiguration, mapper)
        {
        }
    }
}
