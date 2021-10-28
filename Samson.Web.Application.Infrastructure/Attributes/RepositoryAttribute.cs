using System;

namespace Samson.Web.Application.Infrastructure.Attributes
{
    /// <summary>
    /// Attribute to mark repositories. Provides registrations in DI container
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class RepositoryAttribute : Attribute
    {
    }
}
