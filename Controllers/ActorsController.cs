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

        public ActorsController(BookYourShowContext context, IActorRepo repo)
        {
            this._context = context;
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
            Actors added = await actorRepo.AddActor(actor);
            if (added.ActorId > 0)
            {
                return Ok(added);
            }
            else
            {
                return NotFound();
            }

        }
        #endregion

        #region update actor
        [HttpPut]
        [ProducesResponseType(typeof(Actors), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateActor([FromBody] Actors actor)
        {

            Actors added = await actorRepo.UpdateActor(actor);
            if (added.ActorId > 0)
            {
                return Ok(added);
            }
            else
            {
                return NotFound();
            }

        }
        #endregion

        #region delete actor
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Actors), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteActor(int id)
        {
            Actors actor = await actorRepo.DeleteActor(id);
            if (actor.IsActive == false)
            {
                return Ok(actor);
            }
            else
            {
                return NotFound();
            }

        }
        #endregion
    }
}
