using System;
using Autofac;
using AutoMapper.Contrib.Autofac.DependencyInjection;
using MediatR.Extensions.Autofac.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Samson.Web.Application.Infrastructure.Configuration;
using Samson.Web.Application.Infrastructure.Extensions;
using Samson.Web.Application.ReadModels;

namespace Samson.Web.Application.WebHost
{
    /// <summary>
    /// Module to register all components
    /// </summary>
    public class MainModule : Module
    {
        private readonly IConfiguration _configuration;

        public MainModule(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        /// <summary>
        /// Load all components and modules to DI container
        /// </summary>
        /// <param name="builder">Autofac DI container builder</param>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterDatabaseConfiguration(_configuration);
            builder.RegisterMediatR(typeof(Program).Assembly);
            builder.RegisterAutoMapper(typeof(Program).Assembly);
            builder.RegisterModule<ApplicationContainer>();
            builder.RegisterModule<ReadModelContainer>();
        }
    }
}

