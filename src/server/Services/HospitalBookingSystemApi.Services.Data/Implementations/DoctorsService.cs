namespace HospitalBookingSystemApi.Services.Data.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using HospitalBookingSystemApi.Common;
    using HospitalBookingSystemApi.Data;
    using HospitalBookingSystemApi.Data.Models;
    using HospitalBookingSystemApi.Services.Data.Models.Doctor;
    using HospitalBookingSystemApi.Services.Data.Models.Users;
    using HospitalBookingSystemApi.Services.Mapping;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public class DoctorsService : IDoctorsService
    {
        private readonly HospitalBookingSystemDbContext dbContext;
        private readonly UserManager<User> userManager;
        private readonly IUserService userService;
        private readonly IImageService imageService;

        public DoctorsService(
            HospitalBookingSystemDbContext dbContext,
            UserManager<User> userManager,
            IUserService userService,
            IImageService imageService)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
            this.userService = userService;
            this.imageService = imageService;
        }

        public async Task<bool> ExistsAsync(string id)
            => await this.dbContext.Doctors.AnyAsync(d => d.Id.Equals(id));

        public async Task<bool> IsDeletedAsync(string id)
            => await this.dbContext.Doctors
                .IgnoreQueryFilters()
                .AnyAsync(d => d.Id.Equals(id) && d.IsDeleted);

        public async Task<bool> HasSpecializationAsync(string doctorId, string specializationId)
            => await this.dbContext.DoctorsSpecializations
                .AnyAsync(ds => ds.DoctorId.Equals(doctorId) && ds.SpecializationId.Equals(specializationId));

        public async Task<bool> HasShiftAsync(string doctorId, string shiftId)
            => await this.dbContext.DoctorsShifts
                .AnyAsync(ds => ds.DoctorId.Equals(doctorId) && ds.ShiftId.Equals(shiftId));

        public async Task<bool> UserIsDoctorAsync(string doctorId, User user)
        {
            var doctor = await this.dbContext.Doctors
                .Where(d => d.Id.Equals(doctorId))
                .Include(d => d.User)
                .FirstOrDefaultAsync();

            return doctor is not null && doctor.User.Id.Equals(user.Id);
        }

        public async Task<T> GetAsync<T>(string id)
            => await this.GetAsync<T>(id, false);

        public async Task<T> GetWithDeletedAsync<T>(string id)
            => await this.GetAsync<T>(id, true);

        public async Task<(IEnumerable<T> PageResults, int TotalResults)> GetAllAsync<T>(string speciality, string searchTerm, DateTime date, int page)
            => await this.GetAllAsync<T>(speciality, searchTerm, date, false, page);

        public async Task<(IEnumerable<T> PageResults, int TotalResults)> GetAllWithDeletedAsync<T>(string speciality, string searchTerm, DateTime date, int page)
            => await this.GetAllAsync<T>(speciality, searchTerm, date, true, page);

        public async Task<IEnumerable<T>> GetSpecializationsAsync<T>(string id)
            => await this.dbContext.Doctors
                .Where(d => d.Id.Equals(id))
                .Select(d => d.Specializations)
                .To<T>()
                .ToListAsync();

        public async Task AddSpecializationAsync(AddSpecialization model, string id)
        {
            var doctor = await this.dbContext.Doctors.FindAsync(id);

            doctor.Specializations.Add(new DoctorSpecialization() { DoctorId = id, SpecializationId = model.Id });
            this.dbContext.Attach(doctor);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task RemoveSpecializationAsync(string doctorId, string specializationId)
        {
            var specialization = await this.dbContext.DoctorsSpecializations
                .Where(ds => ds.DoctorId.Equals(doctorId) && ds.SpecializationId.Equals(specializationId))
                .FirstOrDefaultAsync();

            this.dbContext.DoctorsSpecializations.Remove(specialization);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetShiftsAsync<T>(string id)
            => await this.dbContext.Doctors
                .Where(d => d.Id.Equals(id))
                .SelectMany(d => d.Shifts)
                .Select(ds => ds.Shift)
                .To<T>()
                .ToListAsync();

        public async Task AddShiftAsync(AddShiftModel model, string id)
        {
            var doctor = await this.dbContext.Doctors.FindAsync(id);
            var doctorShift = new DoctorShift()
            {
                DoctorId = id,
                ShiftId = model.Id,
            };

            if (await this.dbContext.DoctorsShifts
                .AnyAsync(d => d.DoctorId.Equals(doctorShift.DoctorId) && d.ShiftId.Equals(doctorShift.ShiftId)))
            {
                return;
            }

            doctor.Shifts.Add(doctorShift);
            this.dbContext.Attach(doctor);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task RemoveShiftAsync(string doctorId, string shiftId)
        {
            var shift = await this.dbContext.DoctorsShifts
                .Where(ds => ds.DoctorId.Equals(doctorId) && ds.ShiftId.Equals(shiftId))
                .FirstOrDefaultAsync();

            this.dbContext.DoctorsShifts.Remove(shift);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAppointmentsAsync<T>(string id)
            => await this.dbContext.Doctors
                .Where(d => d.Id.Equals(id))
                .SelectMany(d => d.Appointments)
                .To<T>()
                .ToListAsync();

        public async Task<string> CreateDoctorAsync(CreateDoctorModel model)
        {
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

            var imageUrl = await this.imageService.UploadAsync(model.ImageContent);

            var doctor = new Doctor()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                WorkEmail = model.WorkEmail,
                WorkPhone = model.WorkPhone,
                ImageUrl = imageUrl,
                Education = model.Education,

                UserId = user.Id,
            };

            await this.dbContext.Doctors.AddAsync(doctor);
            await this.dbContext.SaveChangesAsync();

            return doctor.Id;
        }

        public async Task<string> UpdateAsync(string id, UpdateDoctorModel model)
        {
            var doctor = await this.dbContext.Doctors.FindAsync(id);

            doctor.FirstName = model.FirstName;
            doctor.LastName = model.LastName;
            doctor.WorkEmail = model.WorkEmail;
            doctor.WorkPhone = model.WorkPhone;

            this.dbContext.Attach(doctor);
            await this.dbContext.SaveChangesAsync();

            return doctor.Id;
        }

        public async Task<string> DeleteAsync(string id)
        {
            var doctor = await this.dbContext.Doctors.FindAsync(id);

            doctor.IsDeleted = true;
            doctor.DeletedOn = DateTime.UtcNow;

            this.dbContext.Attach(doctor);
            await this.dbContext.SaveChangesAsync();

            return doctor.Id;
        }

        public async Task<string> UnDeleteAsync(string id)
        {
            var doctor = await this.dbContext.Doctors
                .IgnoreQueryFilters()
                .FirstAsync(d => d.Id.Equals(id));

            doctor.IsDeleted = false;
            doctor.DeletedOn = null;

            this.dbContext.Attach(doctor);
            await this.dbContext.SaveChangesAsync();

            return doctor.Id;
        }

        private async Task<T> GetAsync<T>(string id, bool includeDeleted)
            => includeDeleted
                ? await this.dbContext.Doctors.IgnoreQueryFilters().Where(d => d.Id.Equals(id)).To<T>().FirstOrDefaultAsync()
                : await this.dbContext.Doctors.Where(d => d.Id.Equals(id)).To<T>().FirstOrDefaultAsync();

        private async Task<(IEnumerable<T> PageResults, int TotalResults)> GetAllAsync<T>(string speciality, string searchTerm, DateTime date, bool includeDeleted, int page)
        {
            var query = includeDeleted
                ? this.dbContext.Doctors.IgnoreQueryFilters()
                : this.dbContext.Doctors.AsQueryable();

            if (!string.IsNullOrWhiteSpace(speciality) && speciality != "all")
            {
                query = query.Where(d => d.Specializations.Any(s => s.SpecializationId.Equals(speciality)));
            }

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(d => (d.FirstName.ToLower() + " " + d.LastName.ToLower()).Contains(searchTerm.ToLower()));
            }

            if (date >= DateTime.Now)
            {
                var shift = await this.dbContext.Shifts.Where(s => s.Date == date).FirstOrDefaultAsync();

                if (shift != null)
                {
                    var doctorsInShift = (await query
                        .Where(d => d.Shifts.Any(s => s.Shift.Id.Equals(shift.Id)))
                        .Select(d => d.Id)
                        .ToListAsync())
                        .ToHashSet();

                    query = query.Where(d => doctorsInShift.Contains(d.Id));
                }
            }

            var total = await query.CountAsync();

            query = query
                .OrderByDescending(x => x.Likes.Average(l => l.Rating));

            var results = await query
                .Skip((page - 1) * GlobalConstants.PageSize)
                .Take(GlobalConstants.PageSize)
                .To<T>()
                .ToListAsync();

            return (results, total);
        }
    }
}
