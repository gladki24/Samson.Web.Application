using Autofac;
using Samson.Web.Application.Infrastructure.Extensions;

namespace Samson.Web.Application.Persistence
{
    /// <summary>
    /// Module to register Repositories components in DI container
    /// </summary>
    public class PersistenceContainer : Module
    {
        /// <summary>
        /// Load Repositories components to DI Container
        /// </summary>
        /// <param name="builder">Target container builder</param>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterRepositories();
        }
    }
}
