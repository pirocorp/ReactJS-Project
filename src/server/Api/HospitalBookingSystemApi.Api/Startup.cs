﻿namespace HospitalBookingSystemApi.Api
{
    using Common;
    using HospitalBookingSystemApi.Api.Infrastructure.Extensions;
    using HospitalBookingSystemApi.Data;
    using HospitalBookingSystemApi.Data.Common;
    using HospitalBookingSystemApi.Data.Models;
    using HospitalBookingSystemApi.Services;
    using HospitalBookingSystemApi.Services.Implementations;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.OpenApi.Models;

    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // services.AddCors();
            services.AddDbContext<HospitalBookingSystemDbContext>(
                options => options.UseSqlServer(this.configuration.GetConnectionString("DefaultConnection")));

            services
                .AddIdentity<User, ApplicationRole>(IdentityOptionsProvider.GetIdentityOptions)
                .AddEntityFrameworkStores<HospitalBookingSystemDbContext>()
                .AddDefaultTokenProviders(); // just adds the default providers to generate tokens for a password reset, 2-factor authentication, change email, and change telephone.

            services.AddAuthorization();
            services.AddAuthentication(this.configuration.GetSection("Jwt").Get<JwtSettings>());

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = GlobalConstants.SystemName, Version = "v1" });
            });

            services.AddSingleton(this.configuration);

            // Data
            services.AddScoped<IDbQueryRunner, DbQueryRunner>();
            services.AddAutoMapper();

            services.AddTransient<IJwtService, JwtService>();

            services.AddDomainServices();

            // Routing
            services.AddLowercaseRouting();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMigrations(); // Migrate database schema
            app.UseSeeding(); // Seed static data on application startup

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HospitalBookingSystemApi.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseGlobalExceptionHandler(env);

            app.UseRouting();

            // global cors policy
            // app.UseCors(x => x
            //    .AllowAnyOrigin()
            //    .AllowAnyMethod()
            //    .AllowAnyHeader());
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
