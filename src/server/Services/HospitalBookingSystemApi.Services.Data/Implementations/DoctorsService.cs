namespace HospitalBookingSystemApi.Services.Data.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Common;
    using HospitalBookingSystemApi.Data;
    using HospitalBookingSystemApi.Data.Models;
    using HospitalBookingSystemApi.Services.Data.Models.Doctor;
    using HospitalBookingSystemApi.Services.Mapping;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Models.Users;

    public class DoctorsService : IDoctorsService
    {
        private readonly HospitalBookingSystemDbContext dbContext;
        private readonly IUserService userService;
        private readonly UserManager<User> userManager;

        public DoctorsService(
            HospitalBookingSystemDbContext dbContext,
            IUserService userService,
            UserManager<User> userManager)
        {
            this.dbContext = dbContext;
            this.userService = userService;
            this.userManager = userManager;
        }

        public async Task<T> GetAsync<T>(string id)
            => await this.GetAsync<T>(id, false);

        public async Task<T> GetAsyncWithDeleted<T>(string id)
            => await this.GetAsync<T>(id, true);

        public async Task<IEnumerable<T>> GetAllAsync<T>()
            => await this.GetAllAsync<T>(false);

        public async Task<IEnumerable<T>> GetAllAsyncWithDeleted<T>()
            => await this.GetAllAsync<T>(true);

        public async Task<bool> UserIsDoctorAsync(string doctorId, User user)
        {
            var doctor = await this.dbContext.Doctors
                .Where(d => d.Id.Equals(doctorId))
                .Include(d => d.User)
                .FirstOrDefaultAsync();

            return doctor.User.Id.Equals(user.Id);
        }

        public async Task<Doctor> CreateDoctorAsync(CreateDoctorModel model)
        {
            // TODO like User Creation return created object and error one.

            var userModel = new UserRegisterModel()
            {
                Username = model.Username,
                Email = model.WorkEmail,
                Password = model.Password,
            };

            var response = await this.userService.RegisterAsync(userModel, GlobalConstants.RolesNames.Doctor);

            if (!response.Result.Succeeded)
            {
                return null;
            }

            var user = await this.userManager.FindByEmailAsync(response.User.Email);

            var doctor = new Doctor()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                WorkEmail = model.WorkEmail,
                WorkPhone = model.WorkPhone,
                UserId = user.Id,
            };

            await this.dbContext.Doctors.AddAsync(doctor);
            await this.dbContext.SaveChangesAsync();

            return doctor;
        }

        private async Task<T> GetAsync<T>(string id, bool includeDeleted)
            => includeDeleted
                ? await this.dbContext.Doctors.IgnoreQueryFilters().Where(d => d.Id.Equals(id)).To<T>().FirstOrDefaultAsync()
                : await this.dbContext.Doctors.Where(d => d.Id.Equals(id)).To<T>().FirstOrDefaultAsync();

        private async Task<IEnumerable<T>> GetAllAsync<T>(bool includeDeleted)
            => includeDeleted
                ? await this.dbContext.Doctors.IgnoreQueryFilters().To<T>().ToListAsync()
                : await this.dbContext.Doctors.To<T>().ToListAsync();
    }
}
