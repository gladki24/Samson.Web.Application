using System;
using System.Data;
using System.Reflection;
using Autofac;
using Samson.Web.Application.Infrastructure.Configuration;
using Samson.Web.Application.Infrastructure.Attributes;

namespace Samson.Web.Application.Infrastructure.Extensions
{
    /// <summary>
    /// Extension to provide methods to register common components of application
    /// </summary>
    public static class ContainerBuilderExtensions
    {
        /// <summary>
        /// Register all classes annotated as QueryHandler in DI container
        /// </summary>
        /// <param name="container">Target DI container</param>
        /// <param name="assembly">Source assembly to find types</param>
        public static void RegisterQueryHandlers(this ContainerBuilder container, Assembly assembly)
        {
            RegisterAssemblyTypesInContainerAsImplementedInterfaces(container, assembly, type => type.IsQueryHandler());
        }

        /// <summary>
        /// Register all classes annotated as CommandHandler in DI container
        /// </summary>
        /// <param name="container">Target DI container</param>
        /// <param name="assembly">Source assembly to find types</param>
        public static void RegisterCommandHandlers(this ContainerBuilder container, Assembly assembly)
        {
            RegisterAssemblyTypesInContainerAsImplementedInterfaces(container, assembly, type => type.IsCommandHandler());
        }

        /// <summary>
        /// Register all classes annotated as ReadModel in DI container
        /// </summary>
        /// <param name="container">Target DI container</param>
        /// <param name="assembly">Source assembly to find types</param>
        public static void RegisterReadModels(this ContainerBuilder container, Assembly assembly)
        {
            RegisterAssemblyTypesInContainerAsImplementedInterfaces(container, assembly, type => type.IsReadModel());
        }

        /// <summary>
        /// Register all repositories annotated as Repository in DI container
        /// </summary>
        /// <param name="container">Target DI container</param>
        /// <param name="assembly">Source assembly to find types</param>
        public static void RegisterRepositories(this ContainerBuilder container, Assembly assembly)
        {
            RegisterAssemblyTypesInContainerAsImplementedInterfaces(container, assembly, type => type.IsRepository());
        }

        /// <summary>
        /// Register all application services as Service in DI container
        /// </summary>
        /// <param name="container">Target DI container</param>
        /// <param name="assembly">Source assembly to find types</param>
        public static void RegisterServices(this ContainerBuilder container, Assembly assembly)
        {
            RegisterAssemblyTypesInContainerAsImplementedInterfaces(container, assembly, type => type.IsService());;
        }

        /// <summary>
        /// Register all factories as Factory in DI container
        /// </summary>
        /// <param name="container">Target DI container</param>
        /// <param name="assembly">Source assembly to find types</param>
        public static void RegisterFactories(this ContainerBuilder container, Assembly assembly)
        {
            RegisterAssemblyTypesInContainerAsImplementedInterfaces(container, assembly, type => type.IsFactory());
        }

        /// <summary>
        /// Register database configuration in DI container as singleton.
        /// </summary>
        /// <param name="container">Target DI container</param>
        public static void RegisterDatabaseConfiguration(this ContainerBuilder container)
        {
            var mongodDbAtlasConnectionString = Environment.GetEnvironmentVariable("ConnectionString:MongoDB:Atlas");

            if (mongodDbAtlasConnectionString.IsNullOrEmpty())
            {
                throw new NoNullAllowedException();
            }

            container
                .Register(c => new DatabaseConfiguration(mongodDbAtlasConnectionString))
                .As<IDatabaseConfiguration>()
                .SingleInstance();
        }

        /// <summary>
        /// Register types from calling assemblies as implemented interfaces
        /// </summary>
        /// <param name="container">Target DI container</param>
        /// <param name="filter">Specifies which types should be registered</param>
        /// <param name="assembly">Assembly to find types</param>
        private static void RegisterAssemblyTypesInContainerAsImplementedInterfaces(ContainerBuilder container, Assembly assembly, Func<Type, bool> filter)
        {
            container
                .RegisterAssemblyTypes(assembly)
                .Where(filter)
                .AsImplementedInterfaces();
        }
    }
}