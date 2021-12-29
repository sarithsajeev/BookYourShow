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
    [Route("crew")]
    [ApiController]
    public class CrewController : ControllerBase
    {
        private readonly BookYourShowContext _context;
        ICrewRepo crewRepo;

        public CrewController(BookYourShowContext context, ICrewRepo repo)
        {
            this._context = context;
            crewRepo = repo;
        }

        #region get crew members
        [HttpGet]
        [ProducesResponseType(typeof(Crew), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetCrewMembers()
        {
            var crewMembers = await crewRepo.GetCrewMembers();
            Console.WriteLine(crewMembers);
            if (crewMembers == null)
            {
                return NotFound();
            }
            return Ok(crewMembers);
        }
        #endregion

        #region get crew memeber by id
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Crew), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetCrewMember(int id)
        {
            var crewMember = await crewRepo.GetCrewMember(id);
            if (crewMember == null)
            {
                return NotFound();
            }
            return Ok(crewMember);
        }
        #endregion

        #region add member
        [HttpPost]
        [ProducesResponseType(typeof(Crew), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> AddCrewMember([FromBody] Crew crewMember)
        {
            Crew added = await crewRepo.AddCrewMember(crewMember);
            if (added.MemberId > 0)
            {
                return Ok(added);
            }
            else
            {
                return NotFound();
            }

        }
        #endregion

        #region update member
        [HttpPut]
        [ProducesResponseType(typeof(Crew), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateCrew([FromBody] Crew crewMember)
        {

            Crew added = await crewRepo.UpdateCrewMember(crewMember);
            if (added.MemberId > 0)
            {
                return Ok(added);
            }
            else
            {
                return NotFound();
            }

        }
        #endregion

        #region delete member
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Crew), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteCrewMember(int id)
        {
            Crew crewMember = await crewRepo.DeleteCrewMember(id);
            if (crewMember.IsActive == false)
            {
                return Ok(crewMember);
            }
            else
            {
                return NotFound();
            }

        }
        #endregion
    }
}
