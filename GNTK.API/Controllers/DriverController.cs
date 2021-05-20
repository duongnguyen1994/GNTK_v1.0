using GNTK.BAL.Interface;
using GNTK.Domain.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GNTK.API.Controllers
{
    [Authorize]
    public class DriverController : BaseController
    {
        private readonly IDriverService driverService;

        public DriverController(IDriverService driverService)
        {
            this.driverService = driverService;
        }
        [Authorize(Roles = "Driver")]
        [HttpPut]
        [Route("AcceptBooking")]
        public async Task<IActionResult> AcceptBooking(BookingReq request)
        {
            return Ok(await driverService.AcceptBooking(request));
        }
        [Authorize(Roles = "Driver")]
        [HttpPut]
        [Route("ChangeDriverStatus")]
        public async Task<IActionResult> ChangeDriverStatus(string driverId)
        {
            return Ok(await driverService.ChangeDriverStatus(driverId));
        }
        [Authorize(Roles = "Driver")]
        [HttpPut]
        [Route("DropedOffCustomer")]
        public async Task<IActionResult> DropedOffCustomer(BookingReq request)
        {
            return Ok(await driverService.DropedOffCustomer(request));
        }
        [Authorize(Roles = "Driver")]
        [HttpPut]
        [Route("PickedUpCustomer")]
        public async Task<IActionResult> PickedUpCustomer(BookingReq request)
        {
            return Ok(await driverService.PickedUpCustomer(request));
        }
        [HttpGet]
        [Route("GetDriverById")]
        public async Task<IActionResult> GetDriverById(string driverId)
        {
            return Ok(await driverService.GetDriverById(driverId));
        }
        [HttpGet]
        [Route("GetDrivers")]
        public async Task<IActionResult> GetDrivers()
        {
            return Ok(await driverService.GetDrivers());
        }
        [Authorize(Roles = "Driver")]
        [HttpPost]
        [Route("GetBookingsAround")]
        public async Task<IActionResult> GetBookingsAround(BookingsAroundReq request)
        {
            return Ok(await driverService.GetBookingsAround(request));
        }
        [Authorize(Roles = "Driver")]
        [HttpPut]
        [Route("UpdateDriverLocation")]
        public async Task<IActionResult> UpdateDriverLocation(UpdateDriverLocationReq request)
        {
            return Ok(await driverService.UpdateDriverLocation(request));
        }
    }
}
