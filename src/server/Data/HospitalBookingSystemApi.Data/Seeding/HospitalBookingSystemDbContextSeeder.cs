﻿namespace HospitalBookingSystemApi.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Calls all seeders which implement ISeeder interface.
    /// In order of registration.
    /// </summary>
    public class HospitalBookingSystemDbContextSeeder : ISeeder
    {
        public async Task SeedAsync(HospitalBookingSystemDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException(nameof(dbContext));
            }

            if (serviceProvider == null)
            {
                throw new ArgumentNullException(nameof(serviceProvider));
            }

            var logger = serviceProvider
                .GetService<ILoggerFactory>()
                .CreateLogger(typeof(HospitalBookingSystemDbContextSeeder));

            var seeders = new List<ISeeder>
            {
                new RolesSeeder(),
            };

            foreach (var seeder in seeders)
            {
                await seeder.SeedAsync(dbContext, serviceProvider);
                await dbContext.SaveChangesAsync();
                logger.LogInformation($"Seeder {seeder.GetType().Name} done.");
            }
        }
    }
}
