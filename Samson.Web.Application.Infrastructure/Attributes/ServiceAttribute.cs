using System;

namespace Samson.Web.Application.Infrastructure.Attributes
{
    /// <summary>
    /// Attribute to mark application services. Provides registration in DI container.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class ServiceAttribute : Attribute
    {
    }
}
