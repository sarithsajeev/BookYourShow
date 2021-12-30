using BookYourShow.Models;
using BookYourShow.Repository;
using BookYourShow.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourShow.Controllers
{
    [Route("reservation")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        IReservationRepo ReservationRepo;

        public ReservationController( IReservationRepo reservationRepo)
        {
            ReservationRepo = reservationRepo;
        }

        #region add reservation
        [HttpPost]
        [ProducesResponseType(typeof(int),200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddReservation([FromBody] Reservation reserve)
        {
            //check validation of body
            if (ModelState.IsValid)
            {
                var reservationId = await ReservationRepo.AddReservation(reserve);
                if (reservationId > 0)
                {
                    return Ok(reservationId);
                }
                return BadRequest();
            }
            return BadRequest();
        }

        #endregion

        #region reserve seat
        [HttpPut]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(400)]
        [Route("seat")]
        public async Task<IActionResult> ReserveSeat([FromBody] SeatsView reserve)
        {
            if (ModelState.IsValid)
            {
                var status = await ReservationRepo.ReserveSeat(reserve);
                if (status)
                {
                    return Ok();
                }
                return BadRequest();
            }
            return BadRequest();
        }
        #endregion

        #region all reservations
        [HttpGet]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetReservations()
        {
            var reservations = await ReservationRepo.AllReservations();
            if(reservations == null)
            {
                return NotFound();
            }
            return Ok(reservations);
        }

        #endregion

        #region delete reservation
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            var delete = await ReservationRepo.DeleteReservation(id);
            if(delete == false)
            {
                return NotFound();
            }
            return Ok();
        }

        #endregion
    }
}
