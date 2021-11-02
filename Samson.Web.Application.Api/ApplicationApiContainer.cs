using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using AutoMapper.Contrib.Autofac.DependencyInjection;

namespace Samson.Web.Application.Api
{
    /// <summary>
    /// Module to register Application.Api components
    /// </summary>
    public class ApplicationApiContainer : Module
    {
        /// <summary>
        /// Load Application.Api components to DI container
        /// </summary>
        /// <param name="builder">Target container builder</param>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAutoMapper(ThisAssembly);
        }
    }
}
