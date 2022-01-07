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
    [Route("likes")]
    [ApiController]
    public class LikeController : ControllerBase
    {

        ILikeRepo likeRepository;
        public LikeController(ILikeRepo _p)
        {
            likeRepository = _p;
        }

        [HttpPost]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]

        public async Task<IActionResult> AddLike([FromBody] Likes model)
        {
            if (ModelState.IsValid)
            {
                var likeId = await likeRepository.AddLike(model);
                if (likeId > 0)
                {
                    return Ok(likeId);
                }
                else
                {
                    return NotFound();
                }
            }
            return BadRequest();
        }

        [HttpPut]
        [ProducesResponseType(typeof(Likes), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateLike([FromBody] Likes model)
        {
            if (ModelState.IsValid)
            {              
                var like = await likeRepository.UpdateLike(model);
                if (like)
                {
                    return Ok(like);
                }
                return BadRequest();
            }
            return BadRequest();
        }

        [HttpGet]
        [ProducesResponseType(typeof(Likes), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetLike()
        {
            var like = await likeRepository.GetLike();
            if (like == null)
            {
                return NotFound();
            }
            return Ok(like);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Likes), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetLikeById(int id)
        {
            var like = await likeRepository.GetLikeById(id);
            if (like == null)
            {
                return NotFound();
            }
            return Ok(like);
        }
    }
}
