using Autofac;
using Samson.Web.Application.Infrastructure.Extensions;

namespace Samson.Web.Application.ReadModels
{
    /// <summary>
    /// Module to register ReadModel components in DI container
    /// </summary>
    public class ReadModelContainer : Module
    {
        /// <summary>
        /// Load ReadModels components to DI Container
        /// </summary>
        /// <param name="builder">Target container builder</param>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterReadModels(ThisAssembly);
        }
    }
}
