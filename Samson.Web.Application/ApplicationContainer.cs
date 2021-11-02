using Autofac;
using AutoMapper.Contrib.Autofac.DependencyInjection;
using Samson.Web.Application.Infrastructure.Extensions;

namespace Samson.Web.Application
{
    /// <summary>
    /// Module to register Application components
    /// </summary>
    public class ApplicationContainer : Module
    {
        /// <summary>
        /// Load Application components to DI Container
        /// </summary>
        /// <param name="builder">Target container builder</param>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAutoMapper(ThisAssembly);
            builder.RegisterQueryHandlers(ThisAssembly);
            builder.RegisterCommandHandlers(ThisAssembly);
            builder.RegisterServices(ThisAssembly);
            builder.RegisterFactories(ThisAssembly);
        }
    }
}