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
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserRepository loginRepository;

        public UserController(IUserRepository _l)
        {

            loginRepository = _l;
        }

        [HttpGet]
        [ProducesResponseType(typeof(Users), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetUsers()
        {

            var users = await loginRepository.GetUsers();
            if (users == null)
            {
                return NotFound();
            }
            return Ok(users);

        }

        [HttpPost]
        //[Route("AddUser")]
        public async Task<IActionResult> AddUser([FromBody] Users model)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var uId = await loginRepository.AddUser(model);
                    if (uId > 0)
                    {
                        //return ();
                        return Ok(uId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
    }
}
