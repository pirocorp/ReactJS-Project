namespace HospitalBookingSystemApi.Api.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;
    using Common;
    using HospitalBookingSystemApi.Api.Models;
    using HospitalBookingSystemApi.Api.Models.Users;
    using HospitalBookingSystemApi.Data.Models;
    using HospitalBookingSystemApi.Services;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    public class UsersController : BaseController
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IMapper mapper;
        private readonly IJwtService jwtService;

        public UsersController(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IMapper mapper,
            IJwtService jwtService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.mapper = mapper;
            this.jwtService = jwtService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginModel model)
        {
            var user = await this.userManager.Users.SingleOrDefaultAsync(u => u.UserName.Equals(model.Username));
            var cansSignIn = user is not null && await this.signInManager.CanSignInAsync(user);
            var userSignInResult = await this.userManager.CheckPasswordAsync(user, model.Password);

            if (user is null || !userSignInResult || !cansSignIn)
            {
                var error = new ApiErrorModel()
                {
                    Code = nameof(user),
                    Description = ApiConstants.Messages.InvalidCredentials,
                };

                return this.BadRequest(error);
            }

            var response = await this.GenerateJwtToken(model.Username);

            return this.Ok(response);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterModel model)
        {
            var user = new User()
            {
                UserName = model.Username,
                Email = model.Email,
            };

            var userCreatedResult = await this.userManager.CreateAsync(user, model.Password);

            if (userCreatedResult.Succeeded)
            {
                await this.userManager.AddToRoleAsync(user, GlobalConstants.RolesNames.Patient);

                var response = await this.GenerateJwtToken(model.Username);

                return this.Ok(response);
            }

            var error = new ApiErrorModel()
            {
                Code = nameof(this.Register),
                Description = $"{userCreatedResult.Errors.First().Code} {userCreatedResult.Errors.First().Description}",
            };

            return this.BadRequest(error);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            if (this.User.Identity?.IsAuthenticated ?? false)
            {
                var user = await this.userManager.GetUserAsync(this.User);
                var roles = await this.userManager.GetRolesAsync(user);

                var result = new
                {
                    Authenticated = "Authenticated",
                    Roles = string.Join(", ", roles),
                };

                return this.Ok(result);
            }

            return this.Ok("Anonymous");
        }

        private async Task<UserResponseModel> GenerateJwtToken(string username)
        {
            var user = await this.userManager.Users.SingleOrDefaultAsync(u => u.UserName.Equals(username));

            var roles = await this.userManager.GetRolesAsync(user);
            var response = this.mapper.Map<UserResponseModel>(user);
            response.Token = this.jwtService.GenerateJwt(user, roles);

            return response;
        }
    }
}
