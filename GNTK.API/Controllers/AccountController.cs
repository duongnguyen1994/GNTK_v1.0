using GNTK.BAL.Interface;
using GNTK.Domain.Entities;
using GNTK.Domain.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GNTK.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IDriverService driverService;
        private readonly ICustomerService customerService;
        private readonly UserManager<AppIdentityUser> userManager;
        private readonly SignInManager<AppIdentityUser> signInManager;
        private readonly IAuthService authService;

        public AccountController(IDriverService driverService,
                                ICustomerService customerService,
                                UserManager<AppIdentityUser> userManager,
                                SignInManager<AppIdentityUser> signInManager,
                                IAuthService authService)
        {
            this.driverService = driverService;
            this.customerService = customerService;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.authService = authService;
        }
        [HttpPost]
        [Route("CreateDriver")]
        public async Task<IActionResult> CreateDriver(DriverRegisterReq req)
        {
            return Ok(await driverService.CreateDriver(req));
        }
        [HttpPost]
        [Route("CreateCustomer")]
        public async Task<IActionResult> CreateCustomer(CustomerRegisterReq req)
        {
            return Ok(await customerService.CreateCustomer(req));
        }
        [HttpPost]
        [Route("Authenticate")]
        public async Task<IActionResult> Authenticate(LoginReq request)
        {
            try
            {
                var result = await authService.Authenticate(request.Email, request.Password);
                if (result != null)
                    return Ok(new { token = result });
                return BadRequest("Invalid credentials");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }       
    }   
}
