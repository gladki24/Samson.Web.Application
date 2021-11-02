using System;

namespace Samson.Web.Application.Infrastructure.Attributes
{
    /// <summary>
    /// Attribute to mark command handlers. Provides registrations in DI container
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class CommandHandlerAttribute : Attribute
    {
    }
}
