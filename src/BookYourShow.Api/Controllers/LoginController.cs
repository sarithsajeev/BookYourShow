using BookYourShow.Api.Repository;
using BookYourShow.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookYourShow.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public IConfiguration _config;
        ILoginRepository loginRepository;



        public LoginController(IConfiguration config, ILoginRepository _l)
        {
            _config = config;
            loginRepository = _l;
        }

        [AllowAnonymous]
        [HttpGet("{userName}/{password}")]

        public IActionResult Login(string userName, string password)
        {
            IActionResult response = Unauthorized();
            Users dbuser = null;
            dbuser = AuthenticateUser(userName, password);

            if (dbuser != null)
            {
                var tokenString = GenerateJSONWebToken(dbuser);
                response = Ok(new
                {
                    uName = dbuser.UserName,
                    //rId = dbuser.RoleId,
                    token = tokenString
                });
            }
            return response;
        }

        private string GenerateJSONWebToken(Users user)
        {

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));



            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
            _config["Jwt:Issuer"], null, expires: DateTime.Now.AddMinutes(20), signingCredentials: credentials);



            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        private Users AuthenticateUser(string userName, string password)
        {


            Users dbuser = loginRepository.validateUser(userName, password);

            if (dbuser != null)
            {
                return dbuser;

            }
            return null;
        }
    }
}
