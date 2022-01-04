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
    [Route("actors")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        //private readonly BookYourShowContext _context;
        IActorRepo actorRepo;

        public ActorsController(IActorRepo repo)
        {
           
            actorRepo = repo;
        }

        #region get actors
        [HttpGet]
        [ProducesResponseType(typeof(Actors), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetActors()
        {
            var actors = await actorRepo.GetActors();
            Console.WriteLine(actors);
            if (actors == null)
            {
                return NotFound();
            }
            return Ok(actors);
        }
        #endregion

        #region get actor by id
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Actors),200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetActor(int id)
        {
            var actor = await actorRepo.GetActor(id);
            if (actor == null)
            {
                return NotFound();
            }
            return Ok(actor);
        }
        #endregion

        #region add actor
        [HttpPost]
        [ProducesResponseType(typeof(Actors), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> AddActor([FromBody] Actors actor)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {


                var actorId = await actorRepo.AddActor(actor);
                if (actorId != null)
                {
                    return Ok(actorId);
                }
                else
                {
                    return NotFound();
                }

            }
            return BadRequest();

        }
        #endregion

        #region update actor
        [HttpPut]
        [ProducesResponseType(typeof(Actors), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateActor([FromBody] Actors actor)
        {

            //Check the validation of body
            if (ModelState.IsValid)
            {

                await actorRepo.UpdateActor(actor);
                return Ok(actor);

            }
            return BadRequest();

        }
        #endregion

        #region delete actor
        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(typeof(Actors), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteActor(int id)
        {
            var actor = await actorRepo.DeleteActor(id);
            if (actor == null)
            {
                return NotFound();
            }
            return Ok(actor);

        }
        #endregion
    }
}
