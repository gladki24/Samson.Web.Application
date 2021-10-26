using System;
using Samson.Web.Application.Infrastructure.Attributes;

namespace Samson.Web.Application.Infrastructure.Extensions
{
    public static class TypeExtensions
    {
        /// <summary>
        /// Specifies is Type able to register in Autofac container
        /// </summary>
        /// <param name="type">Standard .NET Type</param>
        /// <returns>Type is able to register in Autofac DI container</returns>
        public static bool IsRegistrable(this Type type) =>
            type.IsPublic && !type.IsAbstract && type.IsClass;

        /// <summary>
        /// Specifies is Type able to register as read model in Autofac container
        /// </summary>
        /// <param name="type">Standard .NET type</param>
        /// <returns>Type is able to register as read model in Autofac DI container</returns>
        public static bool IsReadModel(this Type type) =>
            type.IsRegistrable() && type.IsDefined(typeof(ReadModelAttribute), false);

        /// <summary>
        /// Specifies is Type able to register as query handler in Autofac container
        /// </summary>
        /// <param name="type">Standard .NET type</param>
        /// <returns>Type is able to register as query handler in Autofac DI container</returns>
        public static bool IsQueryHandler(this Type type) =>
            type.IsRegistrable() && type.IsDefined(typeof(QueryHandlerAttribute), false);

        /// <summary>
        /// Specifies is Type able to register as command handler in Autofac container
        /// </summary>
        /// <param name="type">Standard .NET type</param>
        /// <returns>Type is able to register as command handler in Autofac DI container</returns>
        public static bool IsCommandHandler(this Type type) => 
            type.IsRegistrable() && type.IsDefined(typeof(CommandHandlerAttribute), false);
        
    }
}
