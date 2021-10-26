using Autofac;
using Samson.Web.Application.Infrastructure.Extensions;

namespace Samson.Web.Application.ReadModels
{
    /// <summary>
    /// Module to register ReadModel components
    /// </summary>
    public class ReadModelContainer : Module
    {
        /// <summary>
        /// Load ReadModels componenets to DI Container
        /// </summary>
        /// <param name="builder"></param>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterReadModels();
        }
    }
}
