using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Samson.Web.Application.Infrastructure;
using Samson.Web.Application.Infrastructure.Attributes;

namespace Samson.Web.Application.UnitTests
{
    public class ConventionUnitTest
    {
        private IEnumerable<Type> types;

        [SetUp]
        public void Setup()
        {
            types = from assembly in AppDomain.CurrentDomain.GetAssemblies()
                from type in assembly.GetTypes()
                select type;
        }

        [Test]
        public void ReadModels_AreAnnotatedByAttribute_ReadModel()
        {
            var classesEndingInReadModel = from type in types
                where !type.FullName.IsNullOrEmpty()
                where type.FullName.EndsWith("ReadModel")
                select type;

            foreach (var readModel in classesEndingInReadModel)
            {
                var hasReadModelAttribute = readModel.IsDefined(typeof(ReadModelAttribute), false);
                Assert.True(hasReadModelAttribute, "Read model has to be annotated by ReadModelAttribute");
            }
        }

        [Test]
        public void QueryHandlers_AreAnnotatedByAttribute_QueryHandler()
        {
            var classesEndingInQueryHandler = from type in types
                where !type.FullName.IsNullOrEmpty()
                where type.FullName.EndsWith("QueryHandler")
                select type;

            foreach (var queryHandler in classesEndingInQueryHandler)
            {
                var hasQueryHandlerAttribute = queryHandler.IsDefined(typeof(ReadModelAttribute), false);
                Assert.True(hasQueryHandlerAttribute, "Query handler has to be annotated by QueryHandlerAttribute");
            }
        }

        [Test]
        public void CommandHandlers_AreAnnotatedByAttribute_CommandHandler()
        {
            var classesEndingInCommandHandler = from type in types
                where !type.FullName.IsNullOrEmpty()
                where type.FullName.EndsWith("CommandHandler")
                select type;

            foreach (var commandHandler in classesEndingInCommandHandler)
            {
                var hasCommandHandlerAttribute = commandHandler.IsDefined(typeof(ReadModelAttribute), false);
                Assert.True(hasCommandHandlerAttribute,
                    "Command handler has to be annotated by CommandHandlerAttribute");
            }
        }

        [Test]
        public void Repositories_AreAnnotatedByAttribute_Repository()
        {
            var classEndingInRepository = from type in types
                where !type.FullName.IsNullOrEmpty()
                where type.FullName.EndsWith("Repository")
                select type;

            foreach (var repository in classEndingInRepository)
            {
                var hasRepositoryAttribute = repository.IsDefined(typeof(RepositoryAttribute), false);
                Assert.True(hasRepositoryAttribute,
                    "Repository has to be annotated by RepositoryAttribute");
            }
        }
    }
}