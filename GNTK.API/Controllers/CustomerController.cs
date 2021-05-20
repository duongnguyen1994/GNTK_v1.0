using GNTK.BAL.Interface;
using GNTK.Domain.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GNTK.API.Controllers
{
    [Authorize]
    public class CustomerController : BaseController
    {       
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }
        [HttpGet]
        [Route("GetCustomerById")]
        public async Task<IActionResult> GetCustomerById(string customerId)
        {
            return Ok(await customerService.GetCustomerById(customerId));
        }
        [HttpGet]
        [Route("GetCustomers")]
        public async Task<IActionResult> GetCustomers()
        {
            return Ok(await customerService.GetCustomers());
        }
        [Authorize(Roles = "Customer")]
        [HttpPost]
        [Route("BookingTransport")]
        public async Task<IActionResult> BookingTransport(BookingTransportReq request)
        {
            return Ok(await customerService.BookingTransport(request));
        }
        [Authorize(Roles = "Customer")]
        [HttpPost]
        [Route("GetDriversAround")]
        public async Task<IActionResult> GetDriversAround(DriversAroundReq request)
        {
            return Ok(await customerService.GetDriversAround(request));
        }
    }
}
