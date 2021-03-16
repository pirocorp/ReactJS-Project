namespace HospitalBookingSystemApi.Services.Data
{
    using System.Threading.Tasks;

    using HospitalBookingSystemApi.Services.Data.Models.Users;

    public interface IUserService
    {
        Task<UserResponseModel> GenerateJwtTokenAsync(string username);

        Task<RegisterResponse> RegisterAsync(UserRegisterModel model, string role);

        Task<bool> UsernameAlreadyExists(string username);

        Task<bool> EmailAlreadyExists(string email);
    }
}
