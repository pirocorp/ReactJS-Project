namespace HospitalBookingSystemApi.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Common;
    using HospitalBookingSystemApi.Api.Infrastructure.Extensions;
    using HospitalBookingSystemApi.Api.Models.Doctors;
    using HospitalBookingSystemApi.Data.Models;
    using HospitalBookingSystemApi.Services.Data;
    using HospitalBookingSystemApi.Services.Data.Models.Doctor;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using static Common.GlobalConstants;

    public class DoctorsController : BaseController
    {
        private readonly IDoctorsService doctorsService;
        private readonly IUserService userService;
        private readonly ISpecializationsService specializationsService;
        private readonly IShiftService shiftService;
        private readonly UserManager<User> userManager;

        public DoctorsController(
            IDoctorsService doctorsService,
            IUserService userService,
            ISpecializationsService specializationsService,
            IShiftService shiftService,
            UserManager<User> userManager)
        {
            this.doctorsService = doctorsService;
            this.userService = userService;
            this.specializationsService = specializationsService;
            this.shiftService = shiftService;
            this.userManager = userManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get([FromQuery] string speciality, [FromQuery] string searchTerm, [FromQuery] DateTime date, [FromQuery] int page = 1)
        {
            if (page <= 0)
            {
                return this.BadRequest(ApiConstants.Errors.PageError);
            }

            if (this.User.IsInRole(RolesNames.Administrator))
            {
                var adminResponse = await GetResponse(this.doctorsService.GetAllWithDeletedAsync<DoctorAdminModel>, speciality, searchTerm, date, page);

                return this.Ok(adminResponse);
            }

            var response = await GetResponse(this.doctorsService.GetAllAsync<DoctorModel>, speciality, searchTerm, date, page);

            return this.Ok(response);
        }

        [HttpGet(ApiConstants.WithId)]
        [AllowAnonymous]
        public async Task<IActionResult> Get(string id)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            if (this.User.IsInRole(RolesNames.Administrator)
                || (this.User.IsInRole(RolesNames.Doctor) && await this.doctorsService.UserIsDoctorAsync(id, user)))
            {
                return this.OkOrNotFound(await this.doctorsService.GetWithDeletedAsync<DoctorAdminModel>(id));
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
        [Authorize(Roles = RolesNames.Administrator + "," + RolesNames.Doctor)]
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

            var user = await this.userManager.GetUserAsync(this.User);

            if (!await this.doctorsService.UserIsDoctorAsync(id, user))
            {
                return this.BadRequest(ApiConstants.Errors.DoctorUpdateInsufficientPermission);
            }

            await this.doctorsService.AddSpecializationAsync(model, id);

            return this.Ok();
        }

        [HttpDelete(ApiConstants.Parameters.DoctorId + ApiConstants.DoctorsEndpoints.Specializations + "/" + ApiConstants.Parameters.SpecializationId)]
        [Authorize(Roles = RolesNames.Doctor)]
        public async Task<IActionResult> DeleteSpecialization(string doctorId, string specializationId)
        {
            if (!await this.doctorsService.ExistsAsync(doctorId))
            {
                return this.NotFound();
            }

            if (!await this.specializationsService.ExistsByIdAsync(specializationId))
            {
                return this.NotFound();
            }

            var user = await this.userManager.GetUserAsync(this.User);

            if (!await this.doctorsService.UserIsDoctorAsync(doctorId, user))
            {
                return this.BadRequest(ApiConstants.Errors.DoctorUpdateInsufficientPermission);
            }

            if (!await this.doctorsService.HasSpecializationAsync(doctorId, specializationId))
            {
                return this.BadRequest(ApiConstants.Errors.DoctorUpdateSpecializationNotFound);
            }

            await this.doctorsService.RemoveSpecializationAsync(doctorId, specializationId);
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

        [HttpPost(ApiConstants.WithId + ApiConstants.DoctorsEndpoints.Shifts)]
        [Authorize(Roles = RolesNames.Doctor)]
        public async Task<IActionResult> PostShift([FromBody] InputShiftModel model, string id)
        {
            if (!await this.doctorsService.ExistsAsync(id))
            {
                return this.NotFound();
            }

            var shift = await this.shiftService.GetShiftAsync<AddShiftModel>(model.Date);

            if (shift is null)
            {
                return this.NotFound();
            }

            var user = await this.userManager.GetUserAsync(this.User);

            if (!await this.doctorsService.UserIsDoctorAsync(id, user))
            {
                return this.BadRequest(ApiConstants.Errors.DoctorUpdateInsufficientPermission);
            }

            await this.doctorsService.AddShiftAsync(shift, id);

            return this.Ok();
        }

        [HttpDelete(ApiConstants.Parameters.DoctorId + ApiConstants.DoctorsEndpoints.Shifts + "/" + ApiConstants.Parameters.ShiftId)]
        [Authorize(Roles = RolesNames.Doctor)]
        public async Task<IActionResult> DeleteShift(string doctorId, string shiftId)
        {
            if (!await this.doctorsService.ExistsAsync(doctorId))
            {
                return this.NotFound();
            }

            if (!await this.shiftService.ExistsAsync(shiftId))
            {
                return this.NotFound();
            }

            var user = await this.userManager.GetUserAsync(this.User);

            if (!await this.doctorsService.UserIsDoctorAsync(doctorId, user))
            {
                return this.BadRequest(ApiConstants.Errors.DoctorUpdateInsufficientPermission);
            }

            if (!await this.doctorsService.HasShiftAsync(doctorId, shiftId))
            {
                return this.BadRequest(ApiConstants.Errors.DoctorUpdateShiftNotFound);
            }

            await this.doctorsService.RemoveShiftAsync(doctorId, shiftId);
            return this.Ok();
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
                return this.BadRequest(ApiConstants.Errors.DoctorCreationUsernameOrEmailInUse);
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
                return this.BadRequest(ApiConstants.Errors.DoctorUpdateInsufficientPermission);
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

        private static async Task<GetResponseModel<T>> GetResponse<T>(Func<string, string, DateTime, int, Task<(IEnumerable<T> PageResults, int TotalResults)>> func, string speciality, string searchTerm, DateTime date, int page)
        {
            var (results, total) = await func(speciality, searchTerm, date, page);

            var response = new GetResponseModel<T>()
            {
                Results = results,
                Total = total,
            };

            return response;
        }
    }
}
