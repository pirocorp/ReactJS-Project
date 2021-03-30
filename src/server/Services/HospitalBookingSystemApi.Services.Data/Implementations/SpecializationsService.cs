namespace HospitalBookingSystemApi.Services.Data.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using HospitalBookingSystemApi.Data;
    using HospitalBookingSystemApi.Data.Models;
    using HospitalBookingSystemApi.Services.Data.Models.Specialization;
    using HospitalBookingSystemApi.Services.Mapping;

    using Microsoft.EntityFrameworkCore;

    public class SpecializationsService : ISpecializationsService
    {
        private readonly HospitalBookingSystemDbContext dbContext;

        public SpecializationsService(HospitalBookingSystemDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> ExistsByIdAsync(string id)
            => await this.dbContext.Specializations.FindAsync(id) != null;

        public async Task<bool> ExistsByNameAsync(string name)
            => await this.dbContext.Specializations.AnyAsync(s => s.Name.ToLower().Equals(name.ToLower()));

        public async Task<string> FindIdAsync(string name)
            => await this.dbContext.Specializations
                .Where(s => s.Name.ToLower().Equals(name.ToLower()))
                .Select(s => s.Id)
                .FirstOrDefaultAsync();

        public async Task<T> GetAsync<T>(string id)
            => await this.dbContext.Specializations
                .Where(s => s.Id.Equals(id))
                .To<T>()
                .FirstOrDefaultAsync();

        public async Task<IEnumerable<T>> GetAllAsync<T>()
            => await this.dbContext.Specializations
                .OrderBy(s => s.Name)
                .To<T>()
                .ToListAsync();

        public async Task<string> CreateAsync(CreateSpecializationModel model)
        {
            var specialization = new Specialization
            {
                Name = model.Name,
            };

            await this.dbContext.Specializations.AddAsync(specialization);
            await this.dbContext.SaveChangesAsync();

            return specialization.Id;
        }
    }
}
