using BookYourShow.Api.Repository;
using BookYourShow.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourShow.Api.Controllers
{
    [Route("reviews")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        IReviewsrepo Reviewsrepo;

        public ReviewsController(IReviewsrepo _Reviewsrepo)
        {
            Reviewsrepo = _Reviewsrepo;

        }

        #region Add Reviews

        [HttpPost]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(400)]

        public async Task<IActionResult> AddReviews([FromBody] Reviews reviews)
        {
            if (ModelState.IsValid)
            {
                var reviewId = await Reviewsrepo.AddReviews(reviews);
                if (reviewId > 0)
                {
                    return Ok(reviewId);
                }
                return BadRequest();
            }
            return BadRequest();
        }

        #endregion


        #region Delete Review

        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteReview(int id)
        {
            
            Reviews review = await Reviewsrepo.DeleteReview(id);
            if (review == null)
            {
                return NotFound();

            }
            else
            {

                return Ok(review);
            }

        }

        #endregion

        #region Update Review

        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> UpdateReviews(Reviews review)
        {
            if (ModelState.IsValid)
            {
                var newreview = await Reviewsrepo.UpdateReviews(review);
                if (newreview != null)
                {
                    return Ok(newreview);
                }
                else
                {
                    return NotFound();
                }
            }
            return BadRequest();
        }
        #endregion


        #region View reviews of a movie

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> ViewAllReview(int id)
        {
            var reviews = await Reviewsrepo.ViewAllReview(id);
            if (reviews == null || reviews.Count == 0)
            {
                return NotFound();

            }
            return Ok(reviews);

        }
        #endregion
    }
}
