using BookYourShow.Api.Repository;
using BookYourShow.Api.ViewModel;
using BookYourShow.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourShow.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        IOfferRepository offerRepository;

        public OfferController(IOfferRepository p)
        {
            offerRepository = p;
        }

        #region Get Offer By movie
        [HttpGet]
        [ProducesResponseType(typeof(OfferViewModel), 200)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> OfferByMovie()
        {
            var offer = await offerRepository.OfferByMovie();
            if (offer == null)
            {
                return NotFound();
            }
            return Ok(offer);
        }
        #endregion

        #region get offer by id

        [HttpGet]
        [Route("/{id}")]
        [ProducesResponseType(typeof(OfferViewModel), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetOfferByMovieId(int id)
        {

            var offer = await offerRepository.GetOfferByMovieId(id);
            if (offer == null)
            {
                return NotFound();
            }
            return Ok(offer);
        }
        #endregion

        #region Add Offers
        [HttpPost]
        [ProducesResponseType(typeof(Offers), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> AddOffers(Offers offer)
        {
            if (ModelState.IsValid)
            {
                var offerId = await offerRepository.AddOffers(offer);
                return Ok(offerId);
            }
            return BadRequest();
        }

        #endregion

        #region Update Offers
        [HttpPut]
        [ProducesResponseType(typeof(Offers), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]

        public async Task<IActionResult> UpdateOffers(Offers offer)
        {
            if (ModelState.IsValid)
            {
                await offerRepository.UpdateOffers(offer);
                return Ok(offer);
            }
            return BadRequest();
        }
        #endregion
    }
}
