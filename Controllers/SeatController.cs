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
    [Route("api")]
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
        [Route("Theatre/{tId}/Seats")]
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
        [Route("Theatre/{tId}/Seats")]

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
        [HttpPut]
        [Route("Theatre/{tId}/Seats")]

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
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("theatre/{tId}/seat/{id}")]

        public async Task<IActionResult> GetSeatById(int id,int tId)
        {

            var s = await seatRepo.GetSeatById(id,tId);

            if (s == null)
            {
                return NotFound("No Seat found");
            }
            return Ok(s);

        }

        #endregion

       /* #region Delete a seat
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("Theatre/{tId}/Seats/{id}")]
        public async Task<IActionResult> DeleteSeat(int id, int tId)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await seatRepo.DeleteSeat(id,tId);
                    return Ok();
                }
                catch (Exception)
                {
                    return BadRequest();
                }

            }
            return BadRequest();
        }
        #endregion*/
    }
}
