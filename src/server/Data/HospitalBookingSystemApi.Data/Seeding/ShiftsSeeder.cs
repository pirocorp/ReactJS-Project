namespace HospitalBookingSystemApi.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    using HospitalBookingSystemApi.Data.Models;

    public class ShiftsSeeder : ISeeder
    {
        public async Task SeedAsync(HospitalBookingSystemDbContext dbContext, IServiceProvider serviceProvider)
        {
            var date = DateTime.UtcNow;

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
