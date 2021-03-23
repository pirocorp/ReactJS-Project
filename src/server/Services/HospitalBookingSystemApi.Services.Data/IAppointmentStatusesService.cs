namespace HospitalBookingSystemApi.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using HospitalBookingSystemApi.Data.Models;

    public interface IAppointmentStatusesService
    {
        Task<IEnumerable<T>> GetAllAsync<T>();

        Task<T> GetByIdAsync<T>(string id);

        Task<string> GetStatusIdAsync(string name);
    }
}
