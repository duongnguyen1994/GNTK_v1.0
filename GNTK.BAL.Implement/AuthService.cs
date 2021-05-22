using GNTK.BAL.Interface;
using GNTK.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GNTK.BAL.Implement
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration config;
        private readonly UserManager<AppIdentityUser> userManager;

        public AuthService(IConfiguration config,
                            UserManager<AppIdentityUser> userManager)
        {
            this.config = config;
            this.userManager = userManager;
        }
        public async Task<Object> Authenticate(string username, string password)
        {
            if(!String.IsNullOrEmpty(username) && !String.IsNullOrEmpty(password))
            {
                var user = await userManager.FindByNameAsync(username);
                if(user !=null)
                {
                    var loginUser = await userManager.CheckPasswordAsync(user, password);
                    if (loginUser)
                    {
                        var roleName = (await userManager.GetRolesAsync(user) as List<string>).FirstOrDefault();                        
                        var claims = new[] {
                        new Claim("id",user.Id),
                        new Claim("fullname", user.Fullname),
                        new Claim("role", roleName)
                        };
                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
                        var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                        var token = new JwtSecurityToken(
                            config["Jwt:Issuer"], 
                            config["Jwt:Audience"], 
                            claims, 
                            expires: DateTime.UtcNow.AddDays(1), 
                            signingCredentials: signIn);
                        return new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(token)
                        };
                    }
                }
            }
            return null;
        }
    }
}
