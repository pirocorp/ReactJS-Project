namespace HospitalBookingSystemApi.Api.Controllers
{
    using System.Threading.Tasks;

    using HospitalBookingSystemApi.Api.Infrastructure.Extensions;
    using HospitalBookingSystemApi.Api.Models;
    using HospitalBookingSystemApi.Api.Models.Doctors;
    using HospitalBookingSystemApi.Data.Models;
    using HospitalBookingSystemApi.Services.Data;
    using HospitalBookingSystemApi.Services.Data.Models.Doctor;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using static Common.GlobalConstants;

    public class DoctorsController : BaseController
    {
        private readonly IDoctorsService doctorsService;
        private readonly IUserService userService;
        private readonly ISpecializationsService specializationsService;
        private readonly UserManager<User> userManager;

        public DoctorsController(
            IDoctorsService doctorsService,
            IUserService userService,
            ISpecializationsService specializationsService,
            UserManager<User> userManager)
        {
            this.doctorsService = doctorsService;
            this.userService = userService;
            this.specializationsService = specializationsService;
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            if (this.User.IsInRole(RolesNames.Administrator))
            {
                return this.Ok(await this.doctorsService.GetAllWithDeletedAsync<DoctorAdminModel>());
            }

            return this.Ok(await this.doctorsService.GetAllAsync<DoctorModel>());
        }

        [HttpGet(ApiConstants.WithId)]
        public async Task<IActionResult> Get(string id)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            if (this.User.IsInRole(RolesNames.Administrator)
                || (this.User.IsInRole(RolesNames.Doctor) && await this.doctorsService.UserIsDoctorAsync(id, user)))
            {
                return this.OkOrNotFound(await this.doctorsService.GetAsyncWithDeleted<DoctorAdminModel>(id));
            }

            return this.OkOrNotFound(await this.doctorsService.GetAsync<DoctorModel>(id));
        }

        [HttpGet(ApiConstants.WithId + ApiConstants.DoctorsEndpoints.Specializations)]
        public async Task<IActionResult> GetSpecializations(string id)
        {
            if (!await this.doctorsService.ExistsAsync(id))
            {
                return this.NotFound();
            }

            return this.OkOrNotFound(await this.doctorsService.GetSpecializationsAsync<SpecializationListingModel>(id));
        }

        [HttpPost(ApiConstants.WithId + ApiConstants.DoctorsEndpoints.Specializations)]
        [Authorize(Roles = RolesNames.Doctor)]
        public async Task<IActionResult> PostSpecialization([FromBody] AddSpecialization model, string id)
        {
            if (!await this.doctorsService.ExistsAsync(id))
            {
                return this.NotFound();
            }

            if (!await this.specializationsService.ExistsByIdAsync(model.Id))
            {
                return this.NotFound();
            }

            await this.doctorsService.AddSpecializationAsync(model, id);

            return this.Ok();
        }

        [HttpGet(ApiConstants.WithId + ApiConstants.DoctorsEndpoints.Shifts)]
        public async Task<IActionResult> GetShifts(string id)
        {
            if (!await this.doctorsService.ExistsAsync(id))
            {
                return this.NotFound();
            }

            return this.OkOrNotFound(await this.doctorsService.GetShiftsAsync<ShiftListingModel>(id));
        }

        [HttpGet(ApiConstants.WithId + ApiConstants.DoctorsEndpoints.Appointments)]
        public async Task<IActionResult> GetAppointments(string id)
        {
            if (!await this.doctorsService.ExistsAsync(id))
            {
                return this.NotFound();
            }

            return this.OkOrNotFound(await this.doctorsService.GetAppointmentsAsync<AppointmentListingModel>(id));
        }

        [HttpPost]
        [Authorize(Roles = RolesNames.Administrator)]
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

        [HttpPut(ApiConstants.WithId)]
        [Authorize(Roles = RolesNames.Administrator + "," + RolesNames.Doctor)]
        public async Task<IActionResult> Put([FromBody] UpdateDoctorModel model, string id)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            if (!this.User.IsInRole(RolesNames.Administrator)
                && (!this.User.IsInRole(RolesNames.Doctor) || await this.doctorsService.UserIsDoctorAsync(id, user)))
            {
                var error = new ApiErrorModel()
                {
                    Code = ApiConstants.Errors.DoctorUpdate,
                    Description = ApiConstants.Errors.InsufficientPermission,
                };

                return this.BadRequest(error);
            }

            if (!await this.doctorsService.ExistsAsync(id))
            {
                return this.NotFound();
            }

            var doctor = await this.doctorsService.UpdateAsync(id, model);
            return this.Ok(doctor);
        }

        [HttpPatch(ApiConstants.WithId + ApiConstants.DoctorsEndpoints.UnDelete)]
        [Authorize(Roles = RolesNames.Administrator)]
        public async Task<IActionResult> Patch(string id)
        {
            if (!await this.doctorsService.IsDeletedAsync(id))
            {
                return this.NotFound();
            }

            return this.Ok(await this.doctorsService.UnDeleteAsync(id));
        }

        [HttpDelete(ApiConstants.WithId)]
        [Authorize(Roles = RolesNames.Administrator)]
        public async Task<IActionResult> Delete(string id)
        {
            if (!await this.doctorsService.ExistsAsync(id))
            {
                return this.NotFound();
            }

            var doctor = await this.doctorsService.DeleteAsync(id);

            return this.Ok(doctor);
        }
    }
}
