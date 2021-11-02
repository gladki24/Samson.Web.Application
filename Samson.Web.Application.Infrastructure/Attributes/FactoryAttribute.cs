using System;

namespace Samson.Web.Application.Infrastructure.Attributes
{
    /// <summary>
    /// Attribute to mark factories. Provides registration in DI container
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class FactoryAttribute : Attribute
    {
    }
}
