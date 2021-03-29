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
                new () { Name = "Urology", ImageURL = "/assets/img/specialities/specialities-01.png", },
                new () { Name = "Neurology", ImageURL = "/assets/img/specialities/specialities-02.png", },
                new () { Name = "Orthopedic", ImageURL = "/assets/img/specialities/specialities-03.png", },
                new () { Name = "Cardiologist", ImageURL = "/assets/img/specialities/specialities-04.png", },
                new () { Name = "Dentist", ImageURL = "/assets/img/specialities/specialities-05.png", },
                new () { Name = "Surgeon", ImageURL = "/assets/img/specialities/specialities-06.png", },
                new () { Name = "GP", ImageURL = "/assets/img/specialities/specialities-07.png", },
                new () { Name = "Otolaryngology", ImageURL = "/assets/img/specialities/specialities-08.png", },
                new () { Name = "Family", ImageURL = "/assets/img/specialities/specialities-09.png", },
                new () { Name = "Ophthalmology", ImageURL = "/assets/img/specialities/specialities-10.webp", },
                new () { Name = "Dermatology", ImageURL = "/assets/img/specialities/specialities-11.png", },
            };

            await dbContext.AddRangeAsync(specializations);
            await dbContext.SaveChangesAsync();
        }
    }
}
