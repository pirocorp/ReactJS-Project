namespace HospitalBookingSystemApi.Api.Controllers
{
    using System.Threading.Tasks;

    using HospitalBookingSystemApi.Api.Models.Patients;
    using HospitalBookingSystemApi.Common;
    using HospitalBookingSystemApi.Services.Data;
    using HospitalBookingSystemApi.Services.Data.Models.Appointment;
    using HospitalBookingSystemApi.Services.Data.Models.Patient;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class PatientsController : BaseController
    {
        private readonly IPatientsService patientsService;
        private readonly IAppointmentService appointmentService;

        public PatientsController(
            IPatientsService patientsService,
            IAppointmentService appointmentService)
        {
            this.patientsService = patientsService;
            this.appointmentService = appointmentService;
        }

        [HttpGet]
        [Authorize(Roles = GlobalConstants.RolesNames.Administrator + "," + GlobalConstants.RolesNames.Doctor)]
        public async Task<IActionResult> Get()
        {
            if (this.User.IsInRole(GlobalConstants.RolesNames.Administrator))
            {
                return this.Ok(await this.patientsService.GetAllWithDeletedAsync<Models.Patients.PatientModel>());
            }

            return this.Ok(await this.patientsService.GetAllAsync<Models.Patients.PatientModel>());
        }

        [HttpGet(ApiConstants.WithId)]
        public async Task<IActionResult> Get(string id)
        {
            if (this.User.IsInRole(GlobalConstants.RolesNames.Administrator))
            {
                return this.Ok(await this.patientsService.GetWithDeletedAsync<Models.Patients.PatientModel>(id));
            }

            return this.Ok(await this.patientsService.GetAsync<Models.Patients.PatientModel>(id));
        }

        [HttpGet(ApiConstants.WithId + ApiConstants.PatientsEndpoints.Appointments)]
        [Authorize(Roles = GlobalConstants.RolesNames.Patient)]
        public async Task<IActionResult> GetAppointments(string id)
        {
            if (!await this.patientsService.UserIsPatientAsync(id, this.User))
            {
                return this.BadRequest(ApiConstants.Errors.PatientInsufficientPermission);
            }

            return this.Ok(this.patientsService.GetAppointments<AppointmentDetailsModel>(id));
        }

        [HttpGet(ApiConstants.Parameters.PatientId + ApiConstants.PatientsEndpoints.Appointments + "/" + ApiConstants.Parameters.AppointmentId)]
        [Authorize(Roles = GlobalConstants.RolesNames.Patient)]
        public async Task<IActionResult> GetAppointment(string patientId, string appointmentId)
        {
            if (!await this.appointmentService.ExistsAsync(appointmentId)
                || !await this.patientsService.ExistsAsync(patientId))
            {
                return this.NotFound();
            }

            if (!await this.patientsService.PatientHasAppointment(patientId, appointmentId))
            {
                return this.BadRequest(ApiConstants.Errors.PatientInsufficientPermission);
            }

            if (!await this.patientsService.UserIsPatientAsync(patientId, this.User))
            {
                return this.BadRequest(ApiConstants.Errors.PatientInsufficientPermission);
            }

            return this.Ok(await this.appointmentService.GetAsync<AppointmentDetailsModel>(appointmentId));
        }

        [HttpPost(ApiConstants.Parameters.PatientId + ApiConstants.PatientsEndpoints.Appointments)]
        [Authorize(Roles = GlobalConstants.RolesNames.Patient)]
        public async Task<IActionResult> PostAppointment([FromBody] CreateAppointment model, string patientId)
        {
            if (!await this.patientsService.ExistsAsync(patientId))
            {
                return this.NotFound();
            }

            if (!await this.patientsService.UserIsPatientAsync(patientId, this.User))
            {
                return this.BadRequest(ApiConstants.Errors.PatientInsufficientPermission);
            }

            return this.Ok(await this.appointmentService.CreateAsync(model, patientId));
        }

        [HttpPatch(
            ApiConstants.Parameters.PatientId
            + ApiConstants.PatientsEndpoints.Appointments
            + "/"
            + ApiConstants.Parameters.AppointmentId
            + ApiConstants.PatientsEndpoints.CancelAppointment)]
        public async Task<IActionResult> PatchAppointment(string patientId, string appointmentId)
        {
            if (!await this.appointmentService.ExistsAsync(appointmentId)
                || !await this.patientsService.ExistsAsync(patientId))
            {
                return this.NotFound();
            }

            if (!await this.patientsService.PatientHasAppointment(patientId, appointmentId))
            {
                return this.BadRequest(ApiConstants.Errors.PatientInsufficientPermission);
            }

            await this.appointmentService.CancelAppointment(appointmentId);
            return this.Ok();
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.RolesNames.Patient)]
        public async Task<IActionResult> Post([FromBody] ServicePatientModel model)
        {
            if (await this.patientsService.UserHasPatientProfileAsync(this.User))
            {
                return this.BadRequest(ApiConstants.Errors.UserAlreadyHavePatientProfile);
            }

            return this.Ok(await this.patientsService.CreatePatientAsync(model, this.User));
        }

        [HttpPut(ApiConstants.WithId)]
        [Authorize(Roles = GlobalConstants.RolesNames.Patient)]
        public async Task<IActionResult> Put([FromBody] ServicePatientModel model, string id)
        {
            if (!await this.patientsService.UserHasPatientProfileAsync(this.User))
            {
                return this.BadRequest(ApiConstants.Errors.UserDoNotHavePatientProfile);
            }

            if (!await this.patientsService.UserIsPatientAsync(id, this.User))
            {
                return this.BadRequest(ApiConstants.Errors.PatientInsufficientPermission);
            }

            return this.Ok(await this.patientsService.UpdateAsync(id, model));
        }

        [HttpPatch(ApiConstants.WithId + ApiConstants.PatientsEndpoints.UnDelete)]
        public async Task<IActionResult> Patch(string id)
        {
            if (!await this.patientsService.IsDeletedAsync(id))
            {
                return this.NotFound();
            }

            return this.Ok(await this.patientsService.UnDeleteAsync(id));
        }

        [HttpDelete(ApiConstants.WithId)]
        [Authorize(Roles = GlobalConstants.RolesNames.Patient)]
        public async Task<IActionResult> Delete(string id)
        {
            if (!await this.patientsService.ExistsAsync(id))
            {
                return this.NotFound();
            }

            if (!await this.patientsService.UserIsPatientAsync(id, this.User))
            {
                return this.BadRequest(ApiConstants.Errors.PatientInsufficientPermission);
            }

            return this.Ok(await this.patientsService.DeleteAsync(id));
        }
    }
}
