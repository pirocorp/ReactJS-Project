namespace HospitalBookingSystemApi.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using HospitalBookingSystemApi.Data.Models;
    using HospitalBookingSystemApi.Services.Data.Models.Doctor;

    public interface IDoctorsService
    {
        Task<bool> ExistsAsync(string id);

        Task<bool> IsDeletedAsync(string id);

        Task<bool> HasSpecializationAsync(string doctorId, string specializationId);

        Task<bool> HasShiftAsync(string doctorId, string shiftId);

        Task<bool> UserIsDoctorAsync(string doctorId, User user);

        Task<T> GetAsync<T>(string id);

        Task<T> GetWithDeletedAsync<T>(string id);

        Task<(IEnumerable<T> PageResults, int TotalResults)> GetAllAsync<T>(string speciality, string searchTerm, int page);

        Task<(IEnumerable<T> PageResults, int TotalResults)> GetAllWithDeletedAsync<T>(string speciality, string searchTerm, int page);

        Task<IEnumerable<T>> GetSpecializationsAsync<T>(string id);

        Task AddSpecializationAsync(AddSpecialization model, string id);

        Task RemoveSpecializationAsync(string doctorId, string specializationId);

        Task<IEnumerable<T>> GetShiftsAsync<T>(string id);

        Task AddShiftAsync(AddShiftModel model, string id);

        Task RemoveShiftAsync(string doctorId, string shiftId);

        Task<IEnumerable<T>> GetAppointmentsAsync<T>(string id);

        Task<string> CreateDoctorAsync(CreateDoctorModel model);

        Task<string> UpdateAsync(string id, UpdateDoctorModel mode);

        Task<string> DeleteAsync(string id);

        Task<string> UnDeleteAsync(string id);
    }
}
