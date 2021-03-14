namespace HospitalBookingSystemApi.Api.Infrastructure.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Mime;
    using System.Text.Json;
    using System.Threading.Tasks;

    using HospitalBookingSystemApi.Api.Models;
    using HospitalBookingSystemApi.Data;
    using HospitalBookingSystemApi.Data.Seeding;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Diagnostics;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseMigrations(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();

            var dbContext = serviceScope.ServiceProvider.GetRequiredService<HospitalBookingSystemDbContext>();
            dbContext.Database.Migrate();

            return app;
        }

        public static IApplicationBuilder UseSeeding(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();

            var dbContext = serviceScope.ServiceProvider
                .GetRequiredService<HospitalBookingSystemDbContext>();

            new HospitalBookingSystemDbContextSeeder()
                .SeedAsync(dbContext, serviceScope.ServiceProvider)
                .GetAwaiter()
                .GetResult();

            return app;
        }

        public static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseExceptionHandler(applicationBuilder => AlternativeAppHandler(applicationBuilder, env));

            return app;
        }

        private static void AlternativeAppHandler(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.Run(context => AlternativeApp(context, env));
        }

        private static async Task AlternativeApp(HttpContext context, IWebHostEnvironment env)
        {
            context.Response.StatusCode = (int)HttpStatusCode.OK;
            context.Response.ContentType = MediaTypeNames.Application.Json;
            var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();

            if (exceptionHandlerFeature?.Error != null)
            {
                var ex = exceptionHandlerFeature.Error;
                while (ex is AggregateException aggregateException
                       && aggregateException.InnerExceptions.Any())
                {
                    ex = aggregateException.InnerExceptions.First();
                }

                // TODO: Log it
                var exceptionMessage = ex.Message;
                if (env.IsDevelopment())
                {
                    exceptionMessage = ex.ToString();
                }

                var errors = new List<ApiErrorModel>()
                {
                    new () { Code = "GLOBAL", Description = exceptionMessage },
                };

                await context.Response
                    .WriteAsync(JsonSerializer.Serialize(errors))
                    .ConfigureAwait(false); // if there is a current context or scheduler to call back to, it pretends as if there isn’t.
            }
        }
    }
}
