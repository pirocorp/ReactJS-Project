namespace HospitalBookingSystemApi.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using HospitalBookingSystemApi.Services.Data.Models.Specialization;

    public interface ISpecializationsService
    {
        Task<bool> ExistsByIdAsync(string id);

        Task<bool> ExistsByNameAsync(string name);

        Task<string> FindIdAsync(string name);

        Task<IEnumerable<T>> GetAllAsync<T>();

        Task<string> CreateAsync(CreateSpecializationModel model);
    }
}
