namespace HospitalBookingSystemApi.Api.Controllers
{
    using System.Threading.Tasks;

    using HospitalBookingSystemApi.Api.Models.Appointments;
    using HospitalBookingSystemApi.Services.Data;
    using Infrastructure.Extensions;
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
    }
}
