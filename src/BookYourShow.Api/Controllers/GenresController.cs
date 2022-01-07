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
    [Route("genres")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        IGenreRepository genreRepository;
        public GenresController(IGenreRepository _p)
        {
            genreRepository = _p;
        }

        #region get genres
        [HttpGet]
        [ProducesResponseType(typeof(Genres), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetGenres()
        {
            var genres = await genreRepository.GetGenres();
            if (genres == null)
            {
                return NotFound();
            }
            return Ok(genres);
        }
        #endregion

        #region add genre
        [HttpPost]
        [ProducesResponseType(typeof(Genres), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddGenre([FromBody] Genres genre)
        {
            if (ModelState.IsValid)
            {
                var genId = await genreRepository.AddGenre(genre);
                if (genId != null)
                {
                    return Ok(genId);
                }
                else
                {
                    return NotFound();
                }
            }
            return BadRequest();
        }
        #endregion

        #region delete genre
        [HttpDelete]
        [ProducesResponseType(typeof(Genres), 200)]
        [ProducesResponseType(404)]
        [Route("{id}")]
        public async Task<IActionResult> DeleteGenre(int id)
        {
            var exp = await genreRepository.DeleteGenre(id);
            if (exp == null)
            {
                return NotFound();
            }
            return Ok(exp);
        }
        #endregion
    }
}
