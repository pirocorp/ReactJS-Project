namespace HospitalBookingSystemApi.Services.Data.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using HospitalBookingSystemApi.Data;
    using HospitalBookingSystemApi.Data.Models;
    using HospitalBookingSystemApi.Services.Mapping;

    using Microsoft.EntityFrameworkCore;

    public sealed class AppointmentStatusesService : IAppointmentStatusesService
    {
        private readonly HospitalBookingSystemDbContext dbContext;

        public AppointmentStatusesService(HospitalBookingSystemDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>()
            => await this.dbContext.AppointmentStatuses.To<T>().ToListAsync();

        public async Task<T> GetByIdAsync<T>(string id)
            => await this.dbContext.AppointmentStatuses
                .Where(a => a.Id.Equals(id))
                .To<T>()
                .FirstOrDefaultAsync();

        public async Task<string> GetStatusIdAsync(string name)
            => await this.dbContext.AppointmentStatuses
                .Where(a => a.Name.ToLower().Equals(name.ToLower()))
                .Select(a => a.Id)
                .FirstOrDefaultAsync();
    }
}
