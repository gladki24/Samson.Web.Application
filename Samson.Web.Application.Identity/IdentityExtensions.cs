using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Samson.Web.Application.Identity.Configuration;

namespace Samson.Web.Application.Identity
{
    /// <summary>
    /// Extensions for IServiceCollection to provide JWT Auth
    /// </summary>
    public static class IdentityExtensions
    {
        /// <summary>
        /// Register JWT authentication in services collection
        /// </summary>
        /// <param name="services">Collection of registered services</param>
        /// <param name="jwtKey">JWT key</param>
        public static void AddJwtAuth(this IServiceCollection services, string jwtKey)
        {
            services
                .AddAuthentication(service =>
                {
                    service.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    service.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(service =>
                {
                    service.RequireHttpsMetadata = false;
                    service.SaveToken = true;
                    service.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtKey)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
        }

        /// <summary>
        /// Register identity configuration in DI container as singleton
        /// </summary>
        public static void RegisterIdentityConfiguration(this ContainerBuilder container)
        {
            var jwtKey = Environment.GetEnvironmentVariable("Authentication:JWT:Key");

            container
                .Register(c => new JwtConfiguration(jwtKey))
                .As<IJwtConfiguration>()
                .SingleInstance();
        }
    }
}