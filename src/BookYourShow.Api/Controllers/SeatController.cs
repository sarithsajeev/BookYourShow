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
    [Route("theatre/{tId}/seat")]
    [ApiController]
    public class SeatController : ControllerBase
    {
        ISeatRepository seatRepo;
        public SeatController(ISeatRepository _s)
        {
            seatRepo = _s;
        }

        #region Get all seats 
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        
        public async Task<IActionResult> GetSeats(int tId)
        {

            var seats = await seatRepo.GetSeats(tId);
            if (seats == null)
            {
                return NotFound();
            }
            return Ok(seats);
        }

        #endregion

        #region Add Seat

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        

        public async Task<IActionResult> AddSeat([FromBody] Seats seat, int tId)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {

                var SeatId = await seatRepo.AddSeat(seat, tId);
                if (SeatId > 0)
                {
                    return Ok(SeatId);
                }
                else
                {
                    return NotFound();
                }

            }
            return BadRequest();

        }

        #endregion

        #region update  a seat details
        [HttpPut("{seatId}")]
        

        public async Task<IActionResult> UpdateSeat([FromBody] Seats seat, int tId)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {

                await seatRepo.UpdateSeat(seat, tId);
                return Ok();
            }
            return BadRequest();

        }

        #endregion

        #region get seat by Id
        [HttpGet("{seatId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("theatre/{tId}/seat/{id}")]

        public async Task<IActionResult> GetSeatById(int tId, int seatId)
        {

            var s = await seatRepo.GetSeatById(tId, seatId);

            if (s == null)
            {
                return NotFound("No Seat found");
            }
            return Ok(s);

        }

        #endregion

      
    }
}
