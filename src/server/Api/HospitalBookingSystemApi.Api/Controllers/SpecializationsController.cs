﻿namespace HospitalBookingSystemApi.Api.Controllers
{
    using System.Threading.Tasks;
    using Common;
    using HospitalBookingSystemApi.Api.Models.Specializations;
    using HospitalBookingSystemApi.Services.Data;
    using HospitalBookingSystemApi.Services.Data.Models.Specialization;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class SpecializationsController : BaseController
    {
        private readonly ISpecializationsService specializationsService;

        public SpecializationsController(ISpecializationsService specializationsService)
        {
            this.specializationsService = specializationsService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
            => this.Ok(await this.specializationsService.GetAllAsync<SpecializationsModel>());

        [HttpPost]
        [Authorize(Roles = GlobalConstants.RolesNames.Administrator + "," + GlobalConstants.RolesNames.Doctor)]
        public async Task<IActionResult> Post([FromBody] CreateSpecializationModel model)
        {
            if (await this.specializationsService.ExistsByNameAsync(model.Name))
            {
                return this.Ok(await this.specializationsService.FindIdAsync(model.Name));
            }

            return this.Ok(await this.specializationsService.CreateAsync(model));
        }
    }
}
