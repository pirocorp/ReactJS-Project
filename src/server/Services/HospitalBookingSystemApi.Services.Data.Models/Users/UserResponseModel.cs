namespace HospitalBookingSystemApi.Services.Data.Models.Users
{
    using AutoMapper;
    using HospitalBookingSystemApi.Data.Models;
    using HospitalBookingSystemApi.Services.Mapping;

    public class UserResponseModel : IMapFrom<User>, IHaveCustomMappings
    {
        public string Username { get; set; }

        public string Email { get; set; }

        [IgnoreMap]
        public string Token { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<User, UserResponseModel>()
                .ForMember(d => d.Username, opt => opt.MapFrom(s => s.UserName));
        }
    }
}
