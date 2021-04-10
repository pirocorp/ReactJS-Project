namespace HospitalBookingSystemApi.Services.Data
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using HospitalBookingSystemApi.Services.Data.Models.Appointment;

    public interface IAppointmentService
    {
        Task<bool> ExistsAsync(string id);

        Task<T> GetAsync<T>(string id);

        Task CancelAppointmentAsync(string appointmentId);

        Task<string> CreateAsync(CreateAppointment model, string patientId);

        Task ChangeAppointmentStatusAsync(string appointmentId, string statusName);
    }
}
