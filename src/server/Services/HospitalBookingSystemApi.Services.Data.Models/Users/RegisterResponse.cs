namespace HospitalBookingSystemApi.Services.Data.Models.Users
{
    using Microsoft.AspNetCore.Identity;

    public class RegisterResponse
    {
        public UserResponseModel User { get; set; }

        public IdentityResult Result { get; set; }
    }
}
