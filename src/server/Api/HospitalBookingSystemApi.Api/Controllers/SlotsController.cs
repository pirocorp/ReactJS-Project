namespace HospitalBookingSystemApi.Api.Controllers
{
    using System.Threading.Tasks;

    using HospitalBookingSystemApi.Api.Models.Slots;
    using HospitalBookingSystemApi.Services.Data;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class SlotsController : BaseController
    {
        private readonly ISlotService slotService;

        public SlotsController(ISlotService slotService)
        {
            this.slotService = slotService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
            => this.Ok(await this.slotService.GetAsync<SlotListingModel>());
    }
}
