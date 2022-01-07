using BookYourShow.Api.ViewModel;
using BookYourShow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourShow.Api.Repository
{
    public interface IReviewsrepo
    {
        /// <summary>
        /// Adding reviews for each movie. 
        /// </summary>
        /// <param name="review"></param>
        /// <returns></returns>
        Task<int> AddReviews(Reviews review);

        /// <summary>
        /// Updating the reviews added for a movies
        /// </summary>
        /// <param name="review"></param>
        /// <returns></returns>
        Task<Reviews> UpdateReviews(Reviews review);

        /// <summary>
        /// Deleting reviews for movie
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Reviews> DeleteReview(int id);

        /// <summary>
        /// View reviews for each movie
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<List<ReviewModel>> ViewAllReview(int id);
    }
}
