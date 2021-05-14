using GNTK.BAL.Interface;
using GNTK.Domain.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GNTK.API.Controllers
{
    public class LocationController : BaseController
    {
        private readonly ILocationService locationService;

        public LocationController(ILocationService locationService)
        {
            this.locationService = locationService;
        }
        [HttpGet]
        [Route("GetProvince")]
        public async Task<IActionResult> GetProvince()
        {
            return Ok(await locationService.GetProvince());
        }
        [HttpPost]
        [Route("GetDistrict")]
        public async Task<IActionResult> GetDistrict(LocationReq request)
        {
            return Ok(await locationService.GetDistrict(request));
        }
        [HttpPost]
        [Route("GetWard")]
        public async Task<IActionResult> GetWard(LocationReq request)
        {
            return Ok(await locationService.GetWard(request));
        }
    }
}
