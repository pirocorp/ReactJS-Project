namespace HospitalBookingSystemApi.Api.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using HospitalBookingSystemApi.Api.Infrastructure.Extensions;
    using HospitalBookingSystemApi.Api.Models;
    using HospitalBookingSystemApi.Api.Models.Doctors;
    using HospitalBookingSystemApi.Common;
    using HospitalBookingSystemApi.Data.Models;
    using HospitalBookingSystemApi.Services.Data;
    using HospitalBookingSystemApi.Services.Data.Models.Doctor;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class DoctorsController : BaseController
    {
        private readonly IDoctorsService doctorsService;
        private readonly IUserService userService;
        private readonly UserManager<User> userManager;

        public DoctorsController(
            IDoctorsService doctorsService,
            IUserService userService,
            UserManager<User> userManager)
        {
            this.doctorsService = doctorsService;
            this.userService = userService;
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            if (this.User.IsInRole(GlobalConstants.RolesNames.Administrator))
            {
                return this.Ok(await this.doctorsService.GetAllAsync<DoctorAdminModel>());
            }

            return this.Ok(await this.doctorsService.GetAllAsync<DoctorModel>());
        }

        [HttpGet(ApiConstants.WithId)]
        public async Task<IActionResult> Get(string id)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            if (this.User.IsInRole(GlobalConstants.RolesNames.Administrator)
                || (this.User.IsInRole(GlobalConstants.RolesNames.Doctor) && await this.doctorsService.UserIsDoctorAsync(id, user)))
            {
                return this.OkOrNotFound(await this.doctorsService.GetAsync<DoctorAdminModel>(id));
            }

            return this.OkOrNotFound(await this.doctorsService.GetAsync<DoctorModel>(id));
        }

        [HttpPost]
        [Authorize (Roles = GlobalConstants.RolesNames.Administrator)]
        public async Task<IActionResult> Post([FromBody] CreateDoctorModel model)
        {
            if (await this.userService.UsernameAlreadyExists(model.Username)
                || await this.userService.EmailAlreadyExists(model.WorkEmail))
            {
                var error = new ApiErrorModel()
                {
                    Code = ApiConstants.Errors.DoctorCreation,
                    Description = ApiConstants.Errors.UsernameOrEmailInUse,
                };

                return this.BadRequest(error);
            }

            var doctor = await this.doctorsService.CreateDoctorAsync(model);

            return this.Ok(doctor);
        }
    }
}
