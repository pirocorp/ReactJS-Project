﻿namespace HospitalBookingSystemApi.Api.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    [Route("api/[controller]")]
    public class BaseController : Controller
    {
    }
}
