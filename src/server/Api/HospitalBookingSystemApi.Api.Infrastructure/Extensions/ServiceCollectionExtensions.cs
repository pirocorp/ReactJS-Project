﻿namespace HospitalBookingSystemApi.Api.Infrastructure.Extensions
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    using HospitalBookingSystemApi.Api.Models;
    using HospitalBookingSystemApi.Services;
    using HospitalBookingSystemApi.Services.Data;
    using HospitalBookingSystemApi.Services.Data.Models;
    using HospitalBookingSystemApi.Services.Mapping;

    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.IdentityModel.Tokens;

    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Configures JWT authentication.
        /// </summary>
        /// <param name="services">IServiceCollection (DI Container).</param>
        /// <param name="jwtSettings">JWT settings object generated from appsettings.json configuration.</param>
        /// <returns></returns>
        public static IServiceCollection AddAuthentication(this IServiceCollection services, JwtSettings jwtSettings)
        {
            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = jwtSettings.Issuer,
                        ValidAudience = jwtSettings.Issuer,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret)),
                        ClockSkew = TimeSpan.Zero,
                    };
                });

            return services;
        }

        /// <summary>
        /// Add AutoMapper in IServiceCollection (DI Container).
        /// </summary>
        /// <param name="services">IServiceCollection (DI Container).</param>
        /// <returns>IServiceCollection (DI Container) with added AutoMapper.</returns>
        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            // Configuration register all mappings found in these assemblies.
            AutoMapperConfig.RegisterMappings(
                typeof(ErrorViewModel).GetTypeInfo().Assembly,
                typeof(IDataServiceModel).GetTypeInfo().Assembly);

            services.AddSingleton(AutoMapperConfig.MapperInstance); // Register Service

            return services;
        }

        /// <summary>
        /// All routes are lowercase (CEO friendly).
        /// </summary>
        public static IServiceCollection AddLowercaseRouting(this IServiceCollection services)
            => services.AddRouting(routing => routing.LowercaseUrls = true);

        /// <summary>
        /// Register all services which are in assembly of IService interface as transient into IoC Container.
        /// </summary>
        /// <param name="services">IoC Container.</param>
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            Assembly
                .GetAssembly(typeof(IService))
                ?.GetTypes()
                .Where(t => t.IsClass && t.GetInterfaces().Any(i => i.Name.Equals($"I{t.Name}")))
                .Select(t => new
                {
                    Interface = t.GetInterface($"I{t.Name}"),
                    Implementation = t,
                })
                .ToList()
                .ForEach(s => services.AddTransient(s.Interface, s.Implementation));

            return services;
        }
    }
}
