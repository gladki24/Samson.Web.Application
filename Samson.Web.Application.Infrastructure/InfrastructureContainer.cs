using Autofac;
using AutoMapper.Contrib.Autofac.DependencyInjection;

namespace Samson.Web.Application.Infrastructure
{
    /// <summary>
    /// Module to register Infrastructure components.
    /// </summary>
    public class InfrastructureContainer : Module
    {
        /// <summary>
        /// Load Infrastructure components to DI container
        /// </summary>
        /// <param name="builder">Target container builder</param>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAutoMapper(ThisAssembly);
        }
    }
}
