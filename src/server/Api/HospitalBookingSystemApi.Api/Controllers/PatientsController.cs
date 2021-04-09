namespace HospitalBookingSystemApi.Api.Controllers
{
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using AutoMapper;
    using HospitalBookingSystemApi.Api.Models.Patients;
    using HospitalBookingSystemApi.Common;
    using HospitalBookingSystemApi.Services;
    using HospitalBookingSystemApi.Services.Data;
    using HospitalBookingSystemApi.Services.Data.Models.Appointment;
    using HospitalBookingSystemApi.Services.Data.Models.Patient;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class PatientsController : BaseController
    {
        private readonly IPatientsService patientsService;
        private readonly IAppointmentService appointmentService;
        private readonly IImageService imageService;
        private readonly IShiftService shiftService;
        private readonly IMapper mapper;

        public PatientsController(
            IPatientsService patientsService,
            IAppointmentService appointmentService,
            IImageService imageService,
            IShiftService shiftService,
            IMapper mapper)
        {
            this.patientsService = patientsService;
            this.appointmentService = appointmentService;
            this.imageService = imageService;
            this.shiftService = shiftService;
            this.mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = GlobalConstants.RolesNames.Administrator + "," + GlobalConstants.RolesNames.Doctor)]
        public async Task<IActionResult> Get()
        {
            if (this.User.IsInRole(GlobalConstants.RolesNames.Administrator))
            {
                return this.Ok(await this.patientsService.GetAllWithDeletedAsync<PatientModel>());
            }

            return this.Ok(await this.patientsService.GetAllAsync<PatientModel>());
        }

        [HttpGet(ApiConstants.WithId)]
        public async Task<IActionResult> Get(string id)
        {
            if (this.User.IsInRole(GlobalConstants.RolesNames.Administrator))
            {
                return this.Ok(await this.patientsService.GetWithDeletedAsync<PatientModel>(id));
            }

            return this.Ok(await this.patientsService.GetAsync<PatientModel>(id));
        }

        [HttpGet(ApiConstants.WithId + ApiConstants.PatientsEndpoints.Appointments)]
        [Authorize(Roles = GlobalConstants.RolesNames.Patient)]
        public async Task<IActionResult> GetAppointments(string id)
        {
            if (!await this.patientsService.UserIsPatientAsync(id, this.User))
            {
                return this.BadRequest(ApiConstants.Errors.PatientInsufficientPermission);
            }

            return this.Ok(await this.patientsService.GetAppointmentsAsync<AppointmentDetailsModel>(id));
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
        public async Task<IActionResult> PostAppointment([FromBody] InputAppointmentModel inputModel, string patientId)
        {
            if (!await this.patientsService.ExistsAsync(patientId))
            {
                return this.NotFound();
            }

            if (!await this.patientsService.UserIsPatientAsync(patientId, this.User))
            {
                return this.BadRequest(ApiConstants.Errors.PatientInsufficientPermission);
            }

            var shiftId = await this.shiftService.GetShiftIdAsync(inputModel.Date);

            var serviceModel = new CreateAppointment()
            {
                DoctorId = inputModel.DoctorId,
                SlotId = inputModel.SlotId,
                ShiftId = shiftId,
            };

            var response = new
            {
                AppointmentId = await this.appointmentService.CreateAsync(serviceModel, patientId),
            };

            return this.Ok(response);
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
        public async Task<IActionResult> Post([FromForm] PatientInputModel model)
        {
            if (await this.patientsService.UserHasPatientProfileAsync(this.User))
            {
                return this.BadRequest(ApiConstants.Errors.UserAlreadyHavePatientProfile);
            }

            if (await this.patientsService.SSNExists(model.SSN))
            {
                return this.BadRequest(ApiConstants.Errors.PatientSsnError);
            }

            var serviceModel = await this.PatientInputModelToServicePatientModel(model);

            var response = new
            {
                PatientId = await this.patientsService.CreatePatientAsync(serviceModel, this.User),
            };

            return this.Ok(response);
        }

        [HttpPut(ApiConstants.WithId)]
        [Authorize(Roles = GlobalConstants.RolesNames.Patient)]
        public async Task<IActionResult> Put([FromForm] PatientInputModel model, string id)
        {
            if (!await this.patientsService.UserHasPatientProfileAsync(this.User))
            {
                return this.BadRequest(ApiConstants.Errors.UserDoNotHavePatientProfile);
            }

            if (!await this.patientsService.UserIsPatientAsync(id, this.User))
            {
                return this.BadRequest(ApiConstants.Errors.PatientInsufficientPermission);
            }

            var serviceModel = await this.PatientInputModelToServicePatientModel(model);

            var response = new
            {
                PatientId = await this.patientsService.UpdateAsync(id, serviceModel),
            };

            return this.Ok(response);
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

        private async Task<ServicePatientModel> PatientInputModelToServicePatientModel(PatientInputModel model)
        {
            var serviceModel = this.mapper.Map<ServicePatientModel>(model);

            if (model.Image is not null)
            {
                var imageFromForm = model.Image;
                string imageUrl;
                await using (var ms = new MemoryStream())
                {
                    await imageFromForm.CopyToAsync(ms);
                    var imageData = ms.ToArray();

                    imageUrl = await this.imageService.UploadAsync(imageData);
                }

                serviceModel.ImageUrl = GlobalConstants.CloudinaryResourceBaseAddress + imageUrl;
            }

            return serviceModel;
        }
    }
}
