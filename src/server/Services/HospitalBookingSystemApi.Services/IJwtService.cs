namespace HospitalBookingSystemApi.Services
{
    using System.Collections.Generic;

    using HospitalBookingSystemApi.Data.Models;

    public interface IJwtService
    {
        string GenerateJwt(User user, IList<string> roles);
    }
}
