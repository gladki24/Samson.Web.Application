using System;
using System.Linq;
using System.Reflection;
using Autofac;

namespace Samson.Web.Application.Infrastructure.Extensions
{
    public static class ContainerBuilderExtensions
    {
        /// <summary>
        /// Register all classes annotated as QueryHandler in DI container
        /// </summary>
        /// <param name="container">Autofac DI container</param>
        public static void RegisterQueryHandlers(this ContainerBuilder container)
        {
            var assembly = Assembly.GetCallingAssembly();

            container
                .RegisterAssemblyTypes(assembly)
                .Where(type => type.IsQueryHandler())
                .AsImplementedInterfaces();
        }

        /// <summary>
        /// Register all classes annotated as CommandHandler in DI container
        /// </summary>
        /// <param name="container">Autofac DI container</param>
        public static void RegisterCommandHandlers(this ContainerBuilder container)
        {
            var assembly = Assembly.GetCallingAssembly();

            container
                .RegisterAssemblyTypes(assembly)
                .Where(type => type.IsCommandHandler())
                .AsImplementedInterfaces();
        }

        /// <summary>
        /// Register all classes annotated as ReadModel in DI container
        /// </summary>
        /// <param name="container">Autofac DI container</param>
        public static void RegisterReadModels(this ContainerBuilder container)
        {
            var assembly = Assembly.GetCallingAssembly();

            container
                .RegisterAssemblyTypes(assembly)
                .Where(type => type.IsReadModel())
                .AsImplementedInterfaces();
        }
    }
}
