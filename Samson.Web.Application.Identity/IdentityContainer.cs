using Autofac;

namespace Samson.Web.Application.Identity
{
    /// <summary>
    /// Module to register components related to identity
    /// </summary>
    public class IdentityContainer : Module
    {
        /// <summary>
        /// Load Identity components into DI container.
        /// </summary>
        /// <param name="builder">Target DI container builder</param>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterIdentityConfiguration();
        }
    }
}
