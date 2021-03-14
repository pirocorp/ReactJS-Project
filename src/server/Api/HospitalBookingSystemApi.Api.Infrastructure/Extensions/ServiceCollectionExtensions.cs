namespace HospitalBookingSystemApi.Api.Infrastructure.Extensions
{
    using System;
    using System.Reflection;
    using System.Text;

    using HospitalBookingSystemApi.Api.Models;
    using HospitalBookingSystemApi.Services.Data.Models;
    using HospitalBookingSystemApi.Services.Mapping;

    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.IdentityModel.Tokens;

    public static class ServiceCollectionExtensions
    {
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
    }
}
