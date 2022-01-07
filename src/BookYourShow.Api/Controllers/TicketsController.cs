using BookYourShow.Repository;
using BookYourShow.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourShow.Controllers
{
    [Route("tickets")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        ITicketsRepo t;
        public TicketsController(ITicketsRepo _t)
        {
            t = _t;
        }

        #region Get tickets by user id 
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(TicketViewModel), 200)]
        [ProducesResponseType(404)]
       

        public async Task<IActionResult> ViewTickets(int id)
        {

            var ticket = await t.ViewTickets(id);
            if (ticket== null|| ticket.Count==0)
            {
                return NotFound();

            }
            else
            {
                return Ok(ticket);
            }

        }
        #endregion
    }
}
