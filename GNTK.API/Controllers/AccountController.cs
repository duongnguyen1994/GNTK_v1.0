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
        private readonly IConfiguration config;

        public AccountController(IDriverService driverService,
                                ICustomerService customerService,
                                UserManager<AppIdentityUser> userManager,
                                SignInManager<AppIdentityUser> signInManager,
                                IConfiguration config)
        {
            this.driverService = driverService;
            this.customerService = customerService;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.config = config;
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
        [Route("Login")]
        public async Task<IActionResult> Login(LoginReq request)
        {
            try
            {
                if (request != null)
                {
                    var user = await userManager.FindByNameAsync(request.Email);
                    if (user != null)
                    {
                        var loginUser = await userManager.CheckPasswordAsync(user, request.Password);
                        if (loginUser)
                        {
                            var loginResult = await signInManager.PasswordSignInAsync(request.Email, request.Password, isPersistent: request.RememberMe, false);
                            if (loginResult.Succeeded)
                            {
                                var claims = new[] {
                                    new Claim(JwtRegisteredClaimNames.Sub, config["Jwt:Subject"]),
                                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                                    new Claim("Id", user.Id),
                                    new Claim("Fullname", user.Fullname),
                                    new Claim("Email", user.Email)
                                   };

                                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));

                                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                                var token = new JwtSecurityToken(config["Jwt:Issuer"], config["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);

                                return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                            }
                        }
                    }
                }
                return BadRequest("Invalid Login");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return Ok("Đăng xuất");
        }
    }   
}
