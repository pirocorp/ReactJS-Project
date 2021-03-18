namespace HospitalBookingSystemApi.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using HospitalBookingSystemApi.Data.Models;
    using HospitalBookingSystemApi.Services.Data.Models.Doctor;

    public interface IDoctorsService
    {
        Task<bool> ExistsAsync(string id);

        Task<T> GetAsync<T>(string id);

        Task<IEnumerable<T>> GetSpecializationsAsync<T>(string id);

        Task<IEnumerable<T>> GetShiftsAsync<T>(string id);

        Task<IEnumerable<T>> GetAppointmentsAsync<T>(string id);

        Task<T> GetAsyncWithDeleted<T>(string id);

        Task<IEnumerable<T>> GetAllAsync<T>();

        Task<IEnumerable<T>> GetAllWithDeletedAsync<T>();

        Task<bool> UserIsDoctorAsync(string doctorId, User user);

        Task<Doctor> CreateDoctorAsync(CreateDoctorModel model);

        Task<Doctor> UpdateAsync(string id, UpdateDoctorModel mode);

        Task<Doctor> DeleteAsync(string id);
    }
}
