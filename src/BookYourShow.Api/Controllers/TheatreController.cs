using BookYourShow.Models;
using BookYourShowAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourShowAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TheatreController : ControllerBase
    {
        ITheatreRepo theatreRepository;

        public TheatreController(ITheatreRepo _dr)
        {
            theatreRepository = _dr;
        }

        #region get theatres
        [HttpGet]
        [ProducesResponseType(typeof(Theatre), 200)]
        [ProducesResponseType(404)]
        
        public async Task<IActionResult> GetTheatre()
        {

            var theatres = await theatreRepository.GetTheatre();
            //throw new Exception("Exception occurred!");
            if (theatres == null)
            {
                return NotFound();
            }
            return Ok(theatres);



        }
        #endregion

        #region Get Theatre By Id
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Theatre), 200)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> GetTheatreById(int id)
        {
            var theatre= await theatreRepository.GetTheatreById(id);
            if (theatre == null)
            {
                return NotFound();
            }
            return Ok(theatre);

        }
        #endregion

       


        #region Add Theatre

        [HttpPost]
        [ProducesResponseType(typeof(Theatre), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        //[Authorize(AuthenticationSchemes = "Bearer")]
        //[Route("addtheatre")]

        public async Task<IActionResult> AddTheatre([FromBody] Theatre theatre)
        {
            // check the validation of body
            if (ModelState.IsValid)
            {

                var theatreId = await theatreRepository.AddTheatre(theatre);
                if (theatreId > 0)
                {
                    return Ok(theatreId);
                }
                else
                {
                    return NotFound();
                }
            }
            return BadRequest();
        }
        #endregion

        #region update Theatre

        [HttpPut]
        [ProducesResponseType(typeof(Theatre), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        
        //[Route("updatetheatre")]
        public async Task<IActionResult> UpdateTheatre([FromBody] Theatre theatre)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
               var _theatre= await theatreRepository.UpdateTheatre(theatre);
                if (_theatre)
                {
                    return Ok(_theatre);
                }
                return BadRequest();

            }
            return BadRequest();
        }

       
        #endregion
    }
}
