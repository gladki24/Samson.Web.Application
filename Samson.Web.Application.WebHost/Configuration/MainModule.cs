using Autofac;
using AutoMapper.Contrib.Autofac.DependencyInjection;
using MediatR.Extensions.Autofac.DependencyInjection;
using Samson.Web.Application.Api;
using Samson.Web.Application.Identity;
using Samson.Web.Application.Infrastructure.Extensions;
using Samson.Web.Application.Persistence;
using Samson.Web.Application.ReadModels;

namespace Samson.Web.Application.WebHost.Configuration
{
    /// <summary>
    /// Module to register all components
    /// </summary>
    public class MainModule : Module
    {
        /// <summary>
        /// Load all components and modules to DI container
        /// </summary>
        /// <param name="builder">Autofac DI container builder</param>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterDatabaseConfiguration();
            builder.RegisterMediatR(ThisAssembly);
            builder.RegisterAutoMapper(ThisAssembly);
            builder.RegisterModule<IdentityContainer>();
            builder.RegisterModule<ApplicationContainer>();
            builder.RegisterModule<ApplicationApiContainer>();
            builder.RegisterModule<ReadModelContainer>();
            builder.RegisterModule<PersistenceContainer>();
        }
    }
}

