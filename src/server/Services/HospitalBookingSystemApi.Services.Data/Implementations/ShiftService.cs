namespace HospitalBookingSystemApi.Services.Data.Implementations
{
    using System.Threading.Tasks;

    using HospitalBookingSystemApi.Data;
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
    }
}
