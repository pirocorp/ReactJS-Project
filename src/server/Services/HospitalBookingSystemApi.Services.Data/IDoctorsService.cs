namespace HospitalBookingSystemApi.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using HospitalBookingSystemApi.Data.Models;
    using HospitalBookingSystemApi.Services.Data.Models.Doctor;

    public interface IDoctorsService
    {
        Task<T> GetAsync<T>(string id);

        Task<T> GetAsyncWithDeleted<T>(string id);

        Task<IEnumerable<T>> GetAllAsync<T>();

        Task<IEnumerable<T>> GetAllAsyncWithDeleted<T>();

        Task<bool> UserIsDoctorAsync(string doctorId, User user);

        Task<Doctor> CreateDoctorAsync(CreateDoctorModel model);
    }
}
