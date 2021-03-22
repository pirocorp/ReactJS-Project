namespace HospitalBookingSystemApi.Services.Data
{
    using System.Threading.Tasks;

    public interface IShiftService
    {
        Task<bool> ExistsAsync(string id);
    }
}
