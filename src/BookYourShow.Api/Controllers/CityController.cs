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
    public class CityController : ControllerBase
    {
        ICityRepo postRepository;
        public CityController(ICityRepo _p)
        {
            postRepository = _p;
        }

        #region Get city 

        [HttpGet]
        [ProducesResponseType(typeof(City), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetCity()
        {

            var cities = await postRepository.GetCities();
            if (cities == null)
            {
                return NotFound();
            }
            return Ok(cities);

        }
        #endregion

        #region Add city
        [HttpPost]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddCity(City city)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {

                var cityId = await postRepository.AddCity(city);
                if (cityId > 0)
                {
                    return Ok(cityId);
                }
                else
                {
                    return NotFound();
                }

            }
            return BadRequest();
        }
        #endregion




        #region update city
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateCity(City city)
        {
            //Check the validation of body
            if (ModelState.IsValid)
            {

                await postRepository.UpdateCity(city);
                return Ok();

            }
            else
            {
                return BadRequest();
            }
        }
        #endregion


        #region Get city by id        
        
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(City), 200)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> GetCityById(int id)
        {

            var city = await postRepository.GetCity(id);
            if (city != null)
            {
                return Ok(city);
            }
            return NotFound();

        }
        #endregion


        #region UpdateCityActiveStatus

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateCityActiveStatus(int id)
        {
            //Check the validation of body
            if (ModelState.IsValid)
            {

                await postRepository.UpdateCityActiveStatus(id);
                return Ok();

            }
            return BadRequest();
        }
        #endregion
    }
}
