namespace HospitalBookingSystemApi.Services.Data
{
    using System;
    using System.Threading.Tasks;

    using HospitalBookingSystemApi.Services.Data.Models.Doctor;

    public interface IShiftService
    {
        Task<bool> ExistsAsync(string id);

        Task<T> GetShiftAsync<T>(DateTime date);

        Task<string> GetShiftIdAsync(DateTime date);
    }
}
