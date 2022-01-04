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
        //private readonly BookYourShowContext _context;
        ICrewRepo crewRepo;

        public CrewController( ICrewRepo repo)
        {
            
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
            //check the validation of body
            if (ModelState.IsValid)
            {


                var memberId = await crewRepo.AddCrewMember(crewMember);
                if (memberId != null)
                {
                    return Ok(memberId);
                }
                else
                {
                    return NotFound();
                }

            }
            return BadRequest();

        }
        #endregion

        #region update member
        [HttpPut]
        [ProducesResponseType(typeof(Crew), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateCrew([FromBody] Crew crewMember)
        {

            //Check the validation of body
            if (ModelState.IsValid)
            {

                await crewRepo.UpdateCrewMember(crewMember);
                return Ok(crewMember);

            }
            return BadRequest();

        }
        #endregion

        #region delete member
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Crew), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteCrewMember(int id)
        {
            var member= await crewRepo.DeleteCrewMember(id);
            if (member == null)
            {
                return NotFound();
            }
            return Ok(member);

        }
        #endregion
    }
}
