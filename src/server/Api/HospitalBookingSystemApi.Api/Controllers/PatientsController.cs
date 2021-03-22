namespace HospitalBookingSystemApi.Api.Controllers
{
    using System.Threading.Tasks;

    using HospitalBookingSystemApi.Api.Models.Patients;
    using HospitalBookingSystemApi.Common;
    using HospitalBookingSystemApi.Services.Data;
    using HospitalBookingSystemApi.Services.Data.Models.Patient;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class PatientsController : BaseController
    {
        private readonly IPatientsService patientsService;

        public PatientsController(IPatientsService patientsService)
        {
            this.patientsService = patientsService;
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
                return this.BadRequest(ApiConstants.Errors.PatientUpdate);
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
                return this.BadRequest(ApiConstants.Errors.PatientUpdate);
            }

            return this.Ok(await this.patientsService.DeleteAsync(id));
        }
    }
}
