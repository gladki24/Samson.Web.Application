using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Samson.Web.Application.WebHost
{
    public class Startup
    {
        /// <summary>
        /// Startup of ASP.NET Core application
        /// </summary>
        /// <param name="configuration">Key/Value configuration properties</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Set of key/value configuration properties
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Autofac DI Container
        /// </summary>
        public ILifetimeScope AutofacContainer { get; private set; }

        /// <summary>
        /// Configuration of application services
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Samson.Web.Application", Version = "v1" });
            });
        }

        /// <summary>
        /// Allow to access to Autofac ContainerBuilder to register components in DI container
        /// </summary>
        /// <param name="builder">Used to build IContainer from component registration.</param>
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new MainModule(Configuration));
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Samson.Web.Application v1"));
            }

            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
            AutofacContainer = app.ApplicationServices.GetAutofacRoot();
            app.UseRouting();
        }
    }
}
