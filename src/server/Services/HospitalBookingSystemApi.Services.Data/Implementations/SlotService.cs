namespace HospitalBookingSystemApi.Services.Data.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using HospitalBookingSystemApi.Data;
    using HospitalBookingSystemApi.Services.Mapping;

    using Microsoft.EntityFrameworkCore;

    public class SlotService : ISlotService
    {
        private readonly HospitalBookingSystemDbContext dbContext;

        public SlotService(HospitalBookingSystemDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<T>> GetAsync<T>()
            => await this.dbContext.Slots.OrderBy(s => s.Order).To<T>().ToListAsync();
    }
}
