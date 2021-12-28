using BookYourShow.Models;
using BookYourShow.Repository;
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
    }
}
