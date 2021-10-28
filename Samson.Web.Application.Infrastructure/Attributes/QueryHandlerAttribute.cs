using System;

namespace Samson.Web.Application.Infrastructure.Attributes
{
    /// <summary>
    /// Attribute to mark query handlers. Provides registrations in DI container
    /// </summary>
    [System.AttributeUsage(AttributeTargets.Class)]
    public class QueryHandlerAttribute : System.Attribute
    {
    }
}
