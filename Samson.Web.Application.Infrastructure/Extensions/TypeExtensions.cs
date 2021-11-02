using System;
using Samson.Web.Application.Infrastructure.Attributes;

namespace Samson.Web.Application.Infrastructure.Extensions
{
    public static class TypeExtensions
    {
        /// <summary>
        /// Specifies is Type able to register in DI container
        /// </summary>
        /// <param name="type">Standard .NET Type</param>
        /// <returns>Type is able to register in DI container</returns>
        public static bool IsRegistrable(this Type type) =>
            type.IsPublic && !type.IsAbstract && type.IsClass;

        /// <summary>
        /// Specifies is Type able to register as read model in DI container
        /// </summary>
        /// <param name="type">Standard .NET type</param>
        /// <returns>Type is able to register as read model in DI container</returns>
        public static bool IsReadModel(this Type type) =>
            type.IsRegistrable() && type.IsDefined(typeof(ReadModelAttribute), false);

        /// <summary>
        /// Specifies is Type able to register as query handler in DI container
        /// </summary>
        /// <param name="type">Standard .NET type</param>
        /// <returns>Type is able to register as query handler in DI container</returns>
        public static bool IsQueryHandler(this Type type) =>
            type.IsRegistrable() && type.IsDefined(typeof(QueryHandlerAttribute), false);

        /// <summary>
        /// Specifies is Type able to register as command handler in DI container
        /// </summary>
        /// <param name="type">Standard .NET type</param>
        /// <returns>Type is able to register as command handler in DI container</returns>
        public static bool IsCommandHandler(this Type type) => 
            type.IsRegistrable() && type.IsDefined(typeof(CommandHandlerAttribute), false);

        /// <summary>
        /// Specifies is Type able to register as repository in DI container
        /// </summary>
        /// <param name="type">Standard .NET type</param>
        /// <returns>Type is able to register as repository in DI container</returns>
        public static bool IsRepository(this Type type) =>
            type.IsRegistrable() && type.IsDefined(typeof(RepositoryAttribute), false);

        /// <summary>
        /// Specifies is Type able to register as service in DI container
        /// </summary>
        /// <param name="type">Standard .NET type</param>
        /// <returns>Type is able to register as service in DI container</returns>
        public static bool IsService(this Type type) =>
            type.IsRegistrable() && type.IsDefined(typeof(ServiceAttribute), false);

        /// <summary>
        /// Specifies is Type able to register as factory in DI container
        /// </summary>
        /// <param name="type">Standard .NET type</param>
        /// <returns>Type is able to register as factory in DI container</returns>
        public static bool IsFactory(this Type type) =>
            type.IsRegistrable() && type.IsDefined(typeof(FactoryAttribute), false);
    }
}
