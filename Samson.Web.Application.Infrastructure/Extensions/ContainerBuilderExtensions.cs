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
        public static void RegisterQueryHandlers(this ContainerBuilder container)
        {
            RegisterAssemblyTypesInContainerAsImplementedInterfaces(container, type => type.IsQueryHandler());
        }

        /// <summary>
        /// Register all classes annotated as CommandHandler in DI container
        /// </summary>
        /// <param name="container">Target DI container</param>
        public static void RegisterCommandHandlers(this ContainerBuilder container)
        {
            RegisterAssemblyTypesInContainerAsImplementedInterfaces(container, type => type.IsCommandHandler());
        }

        /// <summary>
        /// Register all classes annotated as ReadModel in DI container
        /// </summary>
        /// <param name="container">Target DI container</param>
        public static void RegisterReadModels(this ContainerBuilder container)
        {
            RegisterAssemblyTypesInContainerAsImplementedInterfaces(container, type => type.IsReadModel());
        }

        /// <summary>
        /// Register all repositories annotated as Repository in DI container
        /// </summary>
        /// <param name="container">Target DI container</param>
        public static void RegisterRepositories(this ContainerBuilder container)
        {
            RegisterAssemblyTypesInContainerAsImplementedInterfaces(container, type => type.IsRepository());
        }

        /// <summary>
        /// Register all application services as Service in DI container
        /// </summary>
        /// <param name="container">Target DI container</param>
        public static void RegisterServices(this ContainerBuilder container)
        {
            RegisterAssemblyTypesInContainerAsImplementedInterfaces(container, type => type.IsService());;
        }

        /// <summary>
        /// Register all factories as Factory in DI container
        /// </summary>
        /// <param name="container"></param>
        public static void RegisterFactories(this ContainerBuilder container)
        {
            RegisterAssemblyTypesInContainerAsImplementedInterfaces(container, type => type.IsFactory());
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
        private static void RegisterAssemblyTypesInContainerAsImplementedInterfaces(ContainerBuilder container, Func<Type, bool> filter)
        {
            var assembly = GetAssembly();

            container
                .RegisterAssemblyTypes(assembly)
                .Where(filter)
                .AsImplementedInterfaces();
        }

        /// <summary>
        /// Get calling assemblies
        /// </summary>
        /// <returns>Assemblies from calling .NET project</returns>
        private static Assembly GetAssembly()
            => Assembly.GetCallingAssembly();
    }
}