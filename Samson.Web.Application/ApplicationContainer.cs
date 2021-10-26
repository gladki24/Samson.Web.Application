using Autofac;
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
        /// <param name="builder"></param>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterQueryHandlers();
            builder.RegisterCommandHandlers();
        }
    }
}