using BookYourShow.Api.Repository;
using BookYourShow.Api.ViewModel;
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
    [Route("login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public IConfiguration _config;
        ILoginRepository _loginRepository;

        public LoginController(IConfiguration config, ILoginRepository loginRepository)
        {
            _config = config;
            _loginRepository = loginRepository;
        }

        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(typeof(Users), 200)]
        [ProducesResponseType(404)]
        public IActionResult Login([FromBody] LoginViewModel user)
        {
            IActionResult response = Unauthorized();
            Users dbuser = null;
            dbuser = _loginRepository.AuthenticateUser(user.UserName,user.Password);
            var tokenString = _loginRepository.GenerateJSONWebToken(dbuser);
            response = Ok(new
                {
                    userName = dbuser.UserName,
                    token = tokenString
                });
            return response;
        }
    }
}
