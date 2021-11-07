using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
using Samson.Web.Application.Infrastructure;
using Samson.Web.Application.Infrastructure.Attributes;
using Samson.Web.Application.Persistence;
using Samson.Web.Application.ReadModels;

namespace Samson.Web.Application.UnitTests
{
    public class ConventionUnitTest
    {
        private IEnumerable<Type> _applicationTypes;
        private IEnumerable<Type> _persistenceTypes;
        private IEnumerable<Type> _readModelTypes;

        /// <summary>
        /// Initialize collection of types to check
        /// </summary>
        [SetUp]
        public void Setup()
        {
            var applicationAssembly = Assembly.GetAssembly(typeof(ApplicationContainer));
            var persistenceAssembly = Assembly.GetAssembly(typeof(PersistenceContainer));
            var readModelAssembly = Assembly.GetAssembly(typeof(ReadModelContainer));

            _applicationTypes = applicationAssembly?.ExportedTypes;
            _persistenceTypes = persistenceAssembly?.ExportedTypes;
            _readModelTypes = readModelAssembly?.ExportedTypes;
        }

        /// <summary>
        /// Checks if all read models marked by ReadModel attribute.
        /// </summary>
        [Test]
        public void ReadModels_AreAnnotatedByAttribute_ReadModel()
        {
            var classesEndingInReadModel = from type in _readModelTypes
                where !type.FullName.IsNullOrEmpty() && !type.IsInterface
                where type.FullName.EndsWith("ReadModel")
                select type;

            foreach (var readModel in classesEndingInReadModel)
            {
                var hasReadModelAttribute = readModel.IsDefined(typeof(ReadModelAttribute), false);
                Assert.True(hasReadModelAttribute, $"Read model has to be annotated by ReadModelAttribute: {readModel.Name}");
            }
        }

        /// <summary>
        /// Checks if all query handlers marked by QueryHandler attribute.
        /// </summary>
        [Test]
        public void QueryHandlers_AreAnnotatedByAttribute_QueryHandler()
        {
            var classesEndingInQueryHandler = from type in _applicationTypes
                where !type.FullName.IsNullOrEmpty() && !type.IsInterface
                where type.FullName.EndsWith("QueryHandler")
                select type;

            foreach (var queryHandler in classesEndingInQueryHandler)
            {
                var hasQueryHandlerAttribute = queryHandler.IsDefined(typeof(QueryHandlerAttribute), false);
                Assert.True(hasQueryHandlerAttribute, $"Query handler has to be annotated by QueryHandlerAttribute: {queryHandler.Name}");
            }
        }

        /// <summary>
        /// Checks if all command handlers marked by CommandHandler attribute.
        /// </summary>
        [Test]
        public void CommandHandlers_AreAnnotatedByAttribute_CommandHandler()
        {
            var classesEndingInCommandHandler = from type in _applicationTypes
                where !type.FullName.IsNullOrEmpty() && !type.IsInterface
                where type.FullName.EndsWith("CommandHandler")
                select type;

            foreach (var commandHandler in classesEndingInCommandHandler)
            {
                var hasCommandHandlerAttribute = commandHandler.IsDefined(typeof(CommandHandlerAttribute), false);
                Assert.True(hasCommandHandlerAttribute, $"Command handler has to be annotated by CommandHandlerAttribute: {commandHandler.Name}");
            }
        }

        /// <summary>
        /// Check if all repositories marked by Repository attribute
        /// </summary>
        [Test]
        public void Repositories_AreAnnotatedByAttribute_Repository()
        {
            var classEndingInRepository = from type in _persistenceTypes
                where !type.FullName.IsNullOrEmpty() && !type.IsInterface
                where type.FullName.EndsWith("Repository")
                select type;

            foreach (var repository in classEndingInRepository)
            {
                var hasRepositoryAttribute = repository.IsDefined(typeof(RepositoryAttribute), false);
                Assert.True(hasRepositoryAttribute, $"Repository has to be annotated by RepositoryAttribute: {repository.Name}");
            }
        }

        /// <summary>
        /// Check if all services end with the name Service
        /// </summary>
        [Test]
        public void Services_AreAnnotatedByAttribute_Service()
        {
            var classEndingInService = from type in _applicationTypes
                where !type.FullName.IsNullOrEmpty() && !type.IsInterface
                where type.FullName.EndsWith("Service")
                select type;

            foreach (var service in classEndingInService)
            {
                var hasServiceAttribute = service.IsDefined(typeof(ServiceAttribute), false);
                Assert.True(hasServiceAttribute, $"Repository has to be annotated by ServiceAttribute: {service.Name}");
            }
        }

        /// <summary>
        /// Check if all domain factories end with the name Factory
        /// </summary>
        [Test]
        public void Factory_AreAnnotatedByAttribute_Factory()
        {
            var classEndingInFactory = from type in _applicationTypes
                where !type.FullName.IsNullOrEmpty() && !type.IsInterface
                where type.FullName.EndsWith("Factory")
                select type;

            foreach (var factory in classEndingInFactory)
            {
                var hasFactoryAttribute = factory.IsDefined(typeof(FactoryAttribute), false);
                Assert.True(hasFactoryAttribute, $"Repository has to be annotated by FactoryAttribute: {factory.Name}");
            }
        }
    }
}