namespace HospitalBookingSystemApi.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    public interface ISeeder
    {
        Task SeedAsync(HospitalBookingSystemDbContext dbContext, IServiceProvider serviceProvider);
    }
}
