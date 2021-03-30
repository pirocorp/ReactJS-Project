namespace HospitalBookingSystemApi.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using HospitalBookingSystemApi.Data.Models;

    using Microsoft.EntityFrameworkCore;

    public class AppointmentStatusesSeeder : ISeeder
    {
        public async Task SeedAsync(HospitalBookingSystemDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (await dbContext.AppointmentStatuses.AnyAsync())
            {
                return;
            }

            var statusNames = new[] { "Pending", "Canceled", "Confirmed", "Completed", "Break" };
            var statuses = statusNames
                .Select(statusName => new AppointmentStatus() { Name = statusName })
                .ToList();

            await dbContext.AppointmentStatuses.AddRangeAsync(statuses);
            await dbContext.SaveChangesAsync();
        }
    }
}
