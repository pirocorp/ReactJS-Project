namespace HospitalBookingSystemApi.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ISlotService
    {
        Task<IEnumerable<T>> GetAsync<T>();
    }
}
