namespace HospitalBookingSystemApi.Services.Data
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using HospitalBookingSystemApi.Services.Data.Models.Patient;

    public interface IPatientsService
    {
        Task<bool> ExistsAsync(string id);

        Task<bool> IsDeletedAsync(string id);

        Task<bool> UserIsPatientAsync(string patientId, ClaimsPrincipal user);

        Task<bool> UserHasPatientProfileAsync(ClaimsPrincipal user);

        Task<T> GetAsync<T>(string id);

        Task<T> GetWithDeletedAsync<T>(string id);

        Task<IEnumerable<T>> GetAllAsync<T>();

        Task<IEnumerable<T>> GetAllWithDeletedAsync<T>();

        Task<IEnumerable<T>> GetAppointments<T>(string id);

        Task<bool> PatientHasAppointment(string patientId, string appointmentId);

        Task<string> CreatePatientAsync(ServicePatientModel model, ClaimsPrincipal user);

        Task<string> UpdateAsync(string patientId, ServicePatientModel model);

        Task<string> DeleteAsync(string id);

        Task<string> UnDeleteAsync(string id);
    }
}
