namespace HospitalBookingSystemApi.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using HospitalBookingSystemApi.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class SpecializationsSeeder : ISeeder
    {
        public async Task SeedAsync(HospitalBookingSystemDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (await dbContext.Specializations.AnyAsync())
            {
                return;
            }

            var specializations = new List<Specialization>()
            {
                new () { Name = "Urology" },
                new () { Name = "Neurology" },
                new () { Name = "Orthopedic" },
                new () { Name = "Cardiologist" },
                new () { Name = "Dentist" },
            };

            await dbContext.AddRangeAsync(specializations);
            await dbContext.SaveChangesAsync();
        }
    }
}
