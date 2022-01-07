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
    [Route("movies")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        IMovieRepository movieRepository;
        public MoviesController(IMovieRepository _p)
        {
            movieRepository = _p;
        }

        #region get movies
        [HttpGet]
        [ProducesResponseType(typeof(Movies), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetAllMovies()
        {
            var movies = await movieRepository.GetAllMovies();
            if (movies == null)
            {
                return NotFound();
            }
            return Ok(movies);
        }
        #endregion

        #region get movie details by id
        [HttpGet]
        [ProducesResponseType(typeof(Movies), 200)]
        [ProducesResponseType(404)]
        [Route("{id}")]
        public async Task<IActionResult> GetMovieById(int id)
        {
            var exp = await movieRepository.GetMovieById(id);
            if (exp == null)
            {
                return NotFound();
            }
            return Ok(exp);
        }
        #endregion

        #region add movie
        [HttpPost]
        [ProducesResponseType(typeof(Movies), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddMovie([FromBody] Movies movie)
        {
            if (ModelState.IsValid)
            {
                var movieId = await movieRepository.AddMovie(movie);
                if (movieId != null)
                {
                    return Ok(movieId);
                }
                else
                {
                    return NotFound();
                }
            }
            return BadRequest();
        }
        #endregion

        #region update movie
        [HttpPut]
        [ProducesResponseType(typeof(Movies), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateMovie(Movies movie)
        {
            if (ModelState.IsValid)
            {
                
                var updated = await movieRepository.UpdateMovie(movie);
                if(updated != null)
                    return Ok(movie);
                else
                    return BadRequest();
            }
            return BadRequest();
        }
        #endregion

        #region deletemovie
        [HttpDelete]
        [ProducesResponseType(typeof(Movies), 200)]
        [ProducesResponseType(404)]
        [Route("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var exp = await movieRepository.DeleteMovie(id);
            if (exp == null)
            {
                return NotFound();
            }
            return Ok(exp);
        }
        #endregion
    }
}
