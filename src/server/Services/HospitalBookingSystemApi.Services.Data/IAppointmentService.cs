namespace HospitalBookingSystemApi.Services.Data
{
    using System.Threading.Tasks;

    using HospitalBookingSystemApi.Services.Data.Models.Appointment;

    public interface IAppointmentService
    {
        Task<bool> ExistsAsync(string id);

        Task<T> GetAsync<T>(string id);

        Task CancelAppointment(string appointmentId);

        Task<string> CreateAsync(CreateAppointment model, string patientId);
    }
}
