using System;

namespace Samson.Web.Application.Infrastructure.Attributes
{
    /// <summary>
    /// Attribute to mark read models. Provides registrations in DI container
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class ReadModelAttribute : Attribute
    {
    }
}
