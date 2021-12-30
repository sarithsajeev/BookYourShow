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
    [Route("[controller]")]
    [ApiController]
    public class LikeController : ControllerBase
    {
        //Constructor Dependency Injection for LikeRepo
        //1.Default constructor - LikeController
        //2.ILikeRepo

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
            //check the validation of body
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
        //[Route("UpdateAppointment")]
        public async Task<IActionResult> UpdateLike([FromBody] Likes model)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {

                await likeRepository.UpdateLike(model);
                return Ok();

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
        //[TypeFilter(typeof(CustomExceptionFilter))]
        public async Task<IActionResult> GetLikeById(int id)
        {
            //throw new Exception("New Exception");
            var like = await likeRepository.GetLikeById(id);
            if (like == null)
            {
                return NotFound();
            }
            return Ok(like);
        }
    }
}
