using Autofac;
using AutoMapper.Contrib.Autofac.DependencyInjection;
using MediatR.Extensions.Autofac.DependencyInjection;

namespace Samson.Web.Application
{
    public class ContainerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterMediatR(typeof(Program).Assembly);
            builder.RegisterAutoMapper(typeof(Program).Assembly);
        }
    }
}
