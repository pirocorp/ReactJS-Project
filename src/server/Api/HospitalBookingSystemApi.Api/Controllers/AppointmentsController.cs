namespace HospitalBookingSystemApi.Api.Controllers
{
    using System.Threading.Tasks;

    using HospitalBookingSystemApi.Api.Infrastructure.Extensions;
    using HospitalBookingSystemApi.Api.Models.Appointments;
    using HospitalBookingSystemApi.Common;
    using HospitalBookingSystemApi.Services.Data;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class AppointmentsController : BaseController
    {
        private readonly IAppointmentService appointmentService;

        public AppointmentsController(IAppointmentService appointmentService)
        {
            this.appointmentService = appointmentService;
        }

        [HttpGet(ApiConstants.WithId)]
        public async Task<IActionResult> Get(string id)
            => this.OkOrNotFound(await this.appointmentService.GetAsync<AppointmentModel>(id));

        [HttpPatch(ApiConstants.WithId)]
        [Authorize(Roles = GlobalConstants.RolesNames.Administrator + "," + GlobalConstants.RolesNames.Doctor)]
        public async Task<IActionResult> Patch(string id, [FromQuery]string status)
        {
            if (!await this.appointmentService.ExistsAsync(id))
            {
                return this.NotFound();
            }

            if (this.User.IsInRole(GlobalConstants.RolesNames.Doctor))
            {
                var appointment = await this.appointmentService.GetAsync<AppointmentStatus>(id);

                if (appointment.StatusName == "Completed"
                    || appointment.StatusName == "Canceled"
                    || (appointment.StatusName == "Confirmed" && status.ToLower() != "completed")
                    || (appointment.StatusName == "Break" && status.ToLower() != "canceled" )
                    || status.ToLower() == "break")
                {
                    return this.Ok();
                }
            }

            await this.appointmentService.ChangeAppointmentStatusAsync(id, status);

            return this.Ok();
        }
    }
}
