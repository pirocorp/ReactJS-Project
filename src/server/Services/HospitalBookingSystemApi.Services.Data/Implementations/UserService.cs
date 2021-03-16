namespace HospitalBookingSystemApi.Services.Data.Implementations
{
    using System.Threading.Tasks;

    using AutoMapper;
    using HospitalBookingSystemApi.Data;
    using HospitalBookingSystemApi.Data.Models;
    using HospitalBookingSystemApi.Services.Data.Models.Users;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public class UserService : IUserService
    {
        private readonly HospitalBookingSystemDbContext dbContext;
        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;
        private readonly IJwtService jwtService;

        public UserService(
            HospitalBookingSystemDbContext dbContext,
            UserManager<User> userManager,
            IMapper mapper,
            IJwtService jwtService)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
            this.mapper = mapper;
            this.jwtService = jwtService;
        }

        public async Task<UserResponseModel> GenerateJwtTokenAsync(string username)
        {
            var user = await this.userManager.Users.SingleOrDefaultAsync(u => u.UserName.Equals(username));

            var roles = await this.userManager.GetRolesAsync(user);
            var response = this.mapper.Map<UserResponseModel>(user);
            response.Token = this.jwtService.GenerateJwt(user, roles);

            return response;
        }

        public async Task<RegisterResponse> RegisterAsync(UserRegisterModel model, string role)
        {
            var user = new User()
            {
                UserName = model.Username,
                Email = model.Email,
            };

            var response = new RegisterResponse();
            response.Result = await this.userManager.CreateAsync(user, model.Password);

            if (!response.Result.Succeeded)
            {
                return response;
            }

            await this.userManager.AddToRoleAsync(user, role);
            response.User = await this.GenerateJwtTokenAsync(model.Username);

            return response;
        }

        public async Task<bool> UsernameAlreadyExists(string username)
            => await this.dbContext.Users.AnyAsync(u => u.UserName.Equals(username));

        public async Task<bool> EmailAlreadyExists(string email)
            => await this.dbContext.Users.AnyAsync(u => u.Email.Equals(email));
    }
}
