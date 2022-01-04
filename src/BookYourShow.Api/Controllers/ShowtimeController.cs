using BookYourShow.Models;
using BookYourShow.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourShow.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ShowTimeController : ControllerBase
    {
        IShowTimeRepo showtimeRepository;

        public ShowTimeController(IShowTimeRepo _p)
        {
            showtimeRepository = _p;
        }
        [HttpGet]
        [ProducesResponseType(typeof(ShowTime), 200)]
        [ProducesResponseType(404)]


        public async Task<IActionResult> GetShowTime()
        {

            var showtime = await showtimeRepository.GetShowTime();
            if (showtime == null)
            {
                return NotFound();
            }
            return Ok(showtime);

        }
        [HttpPost]
        [ProducesResponseType(typeof(ShowTime), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddShowTime(ShowTime showtime)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {

                var resId = await showtimeRepository.AddShowTime(showtime);
                if (resId != null)
                {
                    return Ok(resId);
                }
                else
                {
                    return NotFound();
                }

            }
            return BadRequest();
        }


        [HttpPut]

        [ProducesResponseType(typeof(ShowTime), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateShowTime([FromBody] ShowTime model)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                var show=await showtimeRepository.UpdateShowTime(model);
                if(show)
                {
                    return Ok(show);
                }
                return BadRequest();

            }
            return BadRequest();
        }


        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ShowTime), 200)]
        [ProducesResponseType(404)]
        //[TypeFilter(typeof(CustomExceptionFilter))]
        public async Task<IActionResult> GetShowTimeById(int id)
        {
            //throw new Exception("New Exception");
            var showtime = await showtimeRepository.GetShowTimeById(id);
            if (showtime == null)
            {
                return NotFound();
            }
            return Ok(showtime);
        }

    }
}
