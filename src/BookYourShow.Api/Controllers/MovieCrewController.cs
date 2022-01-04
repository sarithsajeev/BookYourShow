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
    [Route("movie-crew")]
    [ApiController]
    public class MovieCrewController : ControllerBase
    {
       // private readonly BookYourShowContext _context;
        IMovieCrewRepo movieCrewRepo;

        public MovieCrewController(IMovieCrewRepo repo)
        {
           // this._context = context;
            movieCrewRepo = repo;
        }

        #region get all crew members in a movie
        [HttpGet]
        [Route("movie/{id}")]
        [ProducesResponseType(typeof(MovieCrew), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetMovieCrewMembers(int id)
        {
            var crew = await movieCrewRepo.GetCrewMembers(id);

            if (crew == null)
            {
                return NotFound();
            }
            return Ok(crew);
        }
        #endregion

        #region get crew member id
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(MovieCrew), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetCrewMember(int id)
        {
            var member = await movieCrewRepo.GetCrewMember(id);
            if (member == null)
            {
                return NotFound();
            }
            return Ok(member);
        }
        #endregion

        #region add crew member
        [HttpPost]
        [ProducesResponseType(typeof(MovieCrew), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> AddCrewMember([FromBody] MovieCrew member)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {


                var movieCrewId = await movieCrewRepo.AddCrewMember(member);
                if (movieCrewId != null)
                {
                    return Ok(movieCrewId);
                }
                else
                {
                    return NotFound();
                }

            }
            return BadRequest();

        }
        #endregion

        #region update movie crew member
        [HttpPut]
        [ProducesResponseType(typeof(MovieCrew), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateCrewMember([FromBody] MovieCrew member)
        {

            //Check the validation of body
            if (ModelState.IsValid)
            {

                await movieCrewRepo.UpdateCrewMember(member);
                return Ok(member);

            }
            return BadRequest();

        }
        #endregion

        #region delete crew member by movie crew id
        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(typeof(MovieCrew), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteCrewMember(int id)
        {
            var crew = await movieCrewRepo.DeleteCrewMember(id);
            if (crew == null)
            {
                return NotFound();
            }
            return Ok(crew);

        }
        #endregion

        #region delete all crew member in a movie
        [HttpDelete]
        [Route("movie/{id}")]
        [ProducesResponseType(typeof(MovieCrew), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteCrewMembers(int id)
        {
            if (ModelState.IsValid)
            {
                await movieCrewRepo.DeleteCrewMember(id);
                return Ok();
            }
            return BadRequest();

        }
        #endregion
    }
}
