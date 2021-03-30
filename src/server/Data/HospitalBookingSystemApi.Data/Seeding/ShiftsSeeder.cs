namespace HospitalBookingSystemApi.Data.Seeding
{
    using System;

    using System.Threading.Tasks;

    using HospitalBookingSystemApi.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class ShiftsSeeder : ISeeder
    {
        public async Task SeedAsync(HospitalBookingSystemDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (await dbContext.Shifts.AnyAsync())
            {
                return;
            }

            var date = DateTime.Today;

            while (date.Year < 2031)
            {
                var shift = new Shift()
                {
                    Date = date,
                };

                await dbContext.AddAsync(shift);
                date = date.AddDays(1);
            }

            await dbContext.SaveChangesAsync();
        }
    }
}
