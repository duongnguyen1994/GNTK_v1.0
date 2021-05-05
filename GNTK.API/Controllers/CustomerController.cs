using GNTK.BAL.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GNTK.API.Controllers
{
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
    }
}
