namespace HospitalBookingSystemApi.Data.Seeding
{
    using System;
    using System.Threading.Tasks;
    using HospitalBookingSystemApi.Common;
    using HospitalBookingSystemApi.Data.Models;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public class AdminSeeder : ISeeder
    {
        public async Task SeedAsync(HospitalBookingSystemDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            var adminSettings = serviceProvider.GetRequiredService<IConfiguration>().GetSection("Admin").Get<AdminSettings>();

            if (await userManager.FindByEmailAsync(adminSettings.Email) != null)
            {
                return;
            }

            var user = new User()
            {
                UserName = adminSettings.Username,
                Email = adminSettings.Email,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
            };

            await userManager.CreateAsync(user, adminSettings.Password);
            await userManager.AddToRoleAsync(user, GlobalConstants.AdministratorRoleName);
        }
    }
}
