namespace HospitalBookingSystemApi.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using HospitalBookingSystemApi.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class SlotsSeeder : ISeeder
    {
        public async Task SeedAsync(HospitalBookingSystemDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (await dbContext.Slots.AnyAsync())
            {
                return;
            }

            var slots = new List<Slot>()
            {
                new () { Name = "8:00 - 8:30", Order = 1, StartHour = 8, StartMin = 0, EndHour = 8, EndMin = 30 },
                new () { Name = "8:30 - 9:00", Order = 2, StartHour = 8, StartMin = 30, EndHour = 9, EndMin = 00 },
                new () { Name = "9:00 - 9:30", Order = 3, StartHour = 9, StartMin = 0, EndHour = 9, EndMin = 30 },
                new () { Name = "9:30 - 10:00", Order = 4, StartHour = 9, StartMin = 30, EndHour = 10, EndMin = 00 },
                new () { Name = "10:00 - 10:30", Order = 5, StartHour = 10, StartMin = 0, EndHour = 10, EndMin = 30 },
                new () { Name = "10:30 - 11:00", Order = 6, StartHour = 10, StartMin = 30, EndHour = 11, EndMin = 00 },
                new () { Name = "11:00 - 11:30", Order = 7, StartHour = 11, StartMin = 0, EndHour = 11, EndMin = 30 },
                new () { Name = "11:30 - 12:00", Order = 8, StartHour = 11, StartMin = 30, EndHour = 12, EndMin = 00 },
                new () { Name = "12:00 - 12:30", Order = 9, StartHour = 12, StartMin = 0, EndHour = 12, EndMin = 30 },
                new () { Name = "12:30 - 13:00", Order = 10, StartHour = 12, StartMin = 30, EndHour = 13, EndMin = 00 },
                new () { Name = "13:00 - 13:30", Order = 11, StartHour = 13, StartMin = 0, EndHour = 13, EndMin = 30 },
                new () { Name = "13:30 - 14:00", Order = 12, StartHour = 13, StartMin = 30, EndHour = 14, EndMin = 00 },
                new () { Name = "14:00 - 14:30", Order = 13, StartHour = 14, StartMin = 0, EndHour = 14, EndMin = 30 },
                new () { Name = "14:30 - 15:00", Order = 14, StartHour = 14, StartMin = 30, EndHour = 15, EndMin = 00 },
                new () { Name = "15:00 - 15:30", Order = 15, StartHour = 15, StartMin = 0, EndHour = 15, EndMin = 30 },
                new () { Name = "15:30 - 16:00", Order = 16, StartHour = 15, StartMin = 30, EndHour = 16, EndMin = 00 },
                new () { Name = "16:00 - 16:30", Order = 17, StartHour = 16, StartMin = 0, EndHour = 16, EndMin = 30 },
                new () { Name = "16:30 - 17:00", Order = 18, StartHour = 16, StartMin = 30, EndHour = 17, EndMin = 00 },
                new () { Name = "17:00 - 17:30", Order = 19, StartHour = 17, StartMin = 0, EndHour = 17, EndMin = 30 },
                new () { Name = "17:30 - 18:00", Order = 20, StartHour = 17, StartMin = 30, EndHour = 18, EndMin = 00 },
                new () { Name = "18:00 - 18:30", Order = 21, StartHour = 18, StartMin = 0, EndHour = 18, EndMin = 30 },
                new () { Name = "18:30 - 19:00", Order = 22, StartHour = 18, StartMin = 30, EndHour = 19, EndMin = 00 },
            };

            await dbContext.Slots.AddRangeAsync(slots);
            await dbContext.SaveChangesAsync();
        }
    }
}
