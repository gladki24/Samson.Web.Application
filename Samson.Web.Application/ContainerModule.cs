using Autofac;
using MediatR.Extensions.Autofac.DependencyInjection;

namespace Samson.Web.Application
{
    public class ContainerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterMediatR(typeof(Program).Assembly);
        }
    }
}
