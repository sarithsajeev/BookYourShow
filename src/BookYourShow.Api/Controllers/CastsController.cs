using BookYourShow.Models;
using BookYourShow.Api.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourShow.Api.Controllers
{
    [Route("casts")]
    [ApiController]
    public class CastsController : ControllerBase
    {
       // private readonly BookYourShowContext _context;
        ICastsRepo castsRepo;

        public CastsController(ICastsRepo repo)
        {
            
            castsRepo = repo;
        }

        #region get details of all casts in a movie
        [HttpGet]
        [Route("movie/{id}")]
        [ProducesResponseType(typeof(Casts), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetCasts(int id)
        {
            var casts = await castsRepo.GetCasts(id);
            
            if (casts == null)
            {
                return NotFound();
            }
            return Ok(casts);
        }
        #endregion

        #region get cast by id
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(Casts), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetCast(int id)
        {
            var cast = await castsRepo.GetCast(id);
            if (cast == null)
            {
                return NotFound();
            }
            return Ok(cast);
        }
        #endregion

        #region add cast
        [HttpPost]
        [ProducesResponseType(typeof(Casts), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> AddCast([FromBody] Casts cast)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {


                var castId = await castsRepo.AddCast(cast);
                if (castId != null)
                {
                    return Ok(castId);
                }
                else
                {
                    return NotFound();
                }

            }
            return BadRequest();

        }
        #endregion

        #region update cast
        [HttpPut]
        [ProducesResponseType(typeof(Casts), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateCast([FromBody] Casts cast)
        {

            //Check the validation of body
            if (ModelState.IsValid)
            {

                await castsRepo.UpdateCast(cast);
                return Ok(cast);

            }
            return BadRequest();

        }
        #endregion

        #region delete cast by cast id
        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(typeof(Casts), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteCast(int id)
        {
            var cast = await castsRepo.DeleteCast(id);
            if (cast == null)
            {
                return NotFound();
            }
            return Ok(cast);

        }
        #endregion

        #region delete all casts in a movie
        [HttpDelete]
        [Route("movie/{id}")]
        [ProducesResponseType(typeof(Casts), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteCasts(int id)
        {
            var cast = await castsRepo.DeleteCasts(id);
            if (cast == null)
            {
                return NotFound();
            }
            return Ok(cast);


        }
        #endregion

    }
}
