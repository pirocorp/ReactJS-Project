namespace HospitalBookingSystemApi.Services.Data.Implementations
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using HospitalBookingSystemApi.Data;
    using HospitalBookingSystemApi.Services.Mapping;

    using Microsoft.EntityFrameworkCore;

    public class ShiftService : IShiftService
    {
        private readonly HospitalBookingSystemDbContext dbContext;

        public ShiftService(HospitalBookingSystemDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> ExistsAsync(string id)
            => await this.dbContext.Shifts.AnyAsync(s => s.Id.Equals(id));

        public async Task<T> GetShiftAsync<T>(DateTime date)
            => await this.dbContext.Shifts
                .Where(s => s.Date.Equals(date))
                .To<T>()
                .FirstOrDefaultAsync();
    }
}
