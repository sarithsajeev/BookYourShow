using BookYourShow.Api.Repository;
using BookYourShow.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourShow.Api.Controllers
{
    [Route("user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserRepository userRepository;

        public UserController(IUserRepository _l)
        {
            userRepository = _l;
        }

        [HttpGet]
        [ProducesResponseType(typeof(Users), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetUsers()
        {
            var users = await userRepository.GetUsers();
            if (users == null)
            {
                return NotFound();
            }
            return Ok(users);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Users), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> AddUser([FromBody] Users model)
        {
            if (ModelState.IsValid)
            {
                    var userId = await userRepository.AddUser(model);
                    if (userId > 0)
                    {
                        return Ok(userId);
                    }
                    else
                    {
                        return NotFound();
                    }
            }
            return BadRequest();
        }
    }
}
