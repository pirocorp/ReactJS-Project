namespace HospitalBookingSystemApi.Services.Data.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using HospitalBookingSystemApi.Data;
    using HospitalBookingSystemApi.Data.Models;
    using HospitalBookingSystemApi.Services.Data.Models.Patient;
    using HospitalBookingSystemApi.Services.Mapping;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public class PatientsService : IPatientsService
    {
        private readonly HospitalBookingSystemDbContext dbContext;
        private readonly UserManager<User> userManager;

        public PatientsService(
            HospitalBookingSystemDbContext dbContext,
            UserManager<User> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

        public async Task<bool> ExistsAsync(string id)
            => await this.dbContext.Patients.AnyAsync(d => d.Id.Equals(id));

        public async Task<bool> IsDeletedAsync(string id)
            => await this.dbContext.Patients
                .IgnoreQueryFilters()
                .AnyAsync(d => d.Id.Equals(id) && d.IsDeleted);

        public async Task<bool> UserIsPatientAsync(string patientId, ClaimsPrincipal userPrincipal)
        {
            var user = await this.userManager.GetUserAsync(userPrincipal);

            var patient = await this.dbContext.Patients.Where(p => p.Id.Equals(patientId)).FirstOrDefaultAsync();

            if (patient is null || user is null || patient.UserId != user.Id)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> UserHasPatientProfileAsync(ClaimsPrincipal userPrincipal)
        {
            var user = await this.userManager.GetUserAsync(userPrincipal);

            return await this.dbContext.Patients.IgnoreQueryFilters().AnyAsync(p => p.UserId.Equals(user.Id));
        }

        public async Task<bool> SSNExists(string ssn)
            => await this.dbContext.Patients.AnyAsync(p => p.SSN.Equals(ssn));

        public async Task<IEnumerable<T>> GetAllAsync<T>()
            => await this.GetAllAsync<T>(false);

        public async Task<IEnumerable<T>> GetAllWithDeletedAsync<T>()
            => await this.GetAllAsync<T>(true);

        public async Task<T> GetAsync<T>(string id)
            => await this.GetAsync<T>(id, false);

        public async Task<T> GetWithDeletedAsync<T>(string id)
            => await this.GetAsync<T>(id, true);

        public async Task<IEnumerable<T>> GetAppointments<T>(string id)
            => await this.dbContext.Appointments.Where(a => a.Patient.Id.Equals(id)).To<T>().ToListAsync();

        public async Task<bool> PatientHasAppointment(string patientId, string appointmentId)
            => await this.dbContext.Appointments.AnyAsync(a => a.Patient.Id.Equals(patientId) && a.Id.Equals(appointmentId));

        public async Task<string> CreatePatientAsync(ServicePatientModel model, ClaimsPrincipal userPrincipal)
        {
            var user = await this.userManager.GetUserAsync(userPrincipal);

            var patient = new Patient()
            {
                Address = model.Address,
                City = model.City,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Phone = model.Phone,
                SSN = model.SSN,
                ImageUrl = model.ImageUrl,
                UserId = user.Id,
            };

            await this.dbContext.Patients.AddAsync(patient);
            await this.dbContext.SaveChangesAsync();

            return patient.Id;
        }

        public async Task<string> UpdateAsync(string patientId, ServicePatientModel model)
        {
            var patient = await this.dbContext.Patients.Where(p => p.Id.Equals(patientId)).FirstOrDefaultAsync();

            patient.FirstName = model.FirstName;
            patient.LastName = model.LastName;
            patient.Address = model.Address;
            patient.Email = model.Email;
            patient.City = model.City;
            patient.Phone = model.Phone;
            patient.SSN = model.SSN;

            if (model.ImageUrl is not null)
            {
                patient.ImageUrl = model.ImageUrl;
            }

            this.dbContext.Attach(patient);
            await this.dbContext.SaveChangesAsync();

            return patient.Id;
        }

        public async Task<string> DeleteAsync(string id)
        {
            var patient = await this.dbContext.Patients
                .Where(p => p.Id.Equals(id))
                .FirstOrDefaultAsync();

            patient.IsDeleted = true;
            patient.DeletedOn = DateTime.UtcNow;

            this.dbContext.Attach(patient);
            await this.dbContext.SaveChangesAsync();

            return patient.Id;
        }

        public async Task<string> UnDeleteAsync(string id)
        {
            var patient = await this.dbContext.Patients
                .IgnoreQueryFilters()
                .Where(p => p.Id.Equals(id))
                .FirstOrDefaultAsync();

            patient.IsDeleted = false;
            patient.DeletedOn = null;

            this.dbContext.Attach(patient);
            await this.dbContext.SaveChangesAsync();

            return patient.Id;
        }

        private async Task<IEnumerable<T>> GetAllAsync<T>(bool includeDeleted)
            => includeDeleted
                ? await this.dbContext.Patients.IgnoreQueryFilters().To<T>().ToListAsync()
                : await this.dbContext.Patients.To<T>().ToListAsync();

        private async Task<T> GetAsync<T>(string id, bool includeDeleted)
            => includeDeleted
                ? await this.dbContext.Patients.IgnoreQueryFilters().Where(d => d.Id.Equals(id)).To<T>().FirstOrDefaultAsync()
                : await this.dbContext.Patients.Where(d => d.Id.Equals(id)).To<T>().FirstOrDefaultAsync();
    }
}
