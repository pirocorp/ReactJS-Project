﻿namespace HospitalBookingSystemApi.Api.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using HospitalBookingSystemApi.Api.Models;
    using HospitalBookingSystemApi.Api.Models.Users;
    using HospitalBookingSystemApi.Common;
    using HospitalBookingSystemApi.Data.Models;
    using HospitalBookingSystemApi.Services.Data;
    using HospitalBookingSystemApi.Services.Data.Models.Users;
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    public class UsersController : BaseController
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IUserService userService;

        public UsersController(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IUserService userService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
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

        [HttpGet(ApiConstants.WithId)]
        public async Task<IActionResult> Get(string id) => this
            .OkOrNotFound(new { ProfileId = await this.userService.GetUserProfileIdAsync(id) });

        [AllowAnonymous]
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

            var response = await this.userService.GenerateJwtTokenAsync(model.Username);

            return this.Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterModel model)
        {
            if (await this.userService.UsernameAlreadyExists(model.Username)
                || await this.userService.EmailAlreadyExists(model.Email))
            {
                return this.BadRequest(ApiConstants.Errors.RegisterUsernameOrEmailInUse);
            }

            var response = await this.userService.RegisterAsync(model, GlobalConstants.RolesNames.Patient);

            if (!response.Result.Succeeded)
            {
                var error = new ApiErrorModel()
                {
                    Code = nameof(this.Register),
                    Description = $"{response.Result.Errors.First().Code} {response.Result.Errors.First().Description}",
                };

                return this.BadRequest(error);
            }

            return this.Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("exists")]
        public async Task<IActionResult> Exists([FromBody] ExistModel model)
        {
            var exists = false;

            if (model.Email is not null)
            {
                exists = await this.userService.EmailAlreadyExists(model.Email);
            }

            if (model.Username is not null)
            {
                exists = exists || await this.userService.UsernameAlreadyExists(model.Username);
            }

            return await Task.FromResult(this.Ok(new {
                exists,
            }));
        }
    }
}
