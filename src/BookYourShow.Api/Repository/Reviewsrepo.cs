using BookYourShow.Api.ViewModel;
using BookYourShow.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourShow.Api.Repository
{
    public class Reviewsrepo:IReviewsrepo
    {
        private BookYourShowContext db;
        public Reviewsrepo(BookYourShowContext _db)
        {
            db = _db;
        }

        #region Adding Reviews

        public async Task<int> AddReviews(Reviews review)
        {
            if (db != null)
            {
                await db.Reviews.AddAsync(review);
                await db.SaveChangesAsync();
                return review.ReviewId;
            }
            return 0;
        }

        #endregion

        #region Delete Review

        public async Task<Reviews> DeleteReview(int id)
        {
            Reviews review = db.Reviews.FirstOrDefault(Rid => Rid.ReviewId == id);

            if (review != null)
            {

                db.Reviews.Remove(review);
                await db.SaveChangesAsync();
                return review;

            }
            else
            {
                return null;
            }

        }

        #endregion

        #region Update Review
        public async Task<Reviews> UpdateReviews(Reviews review)
        {
            Reviews dbreview = db.Reviews.FirstOrDefault(Rid => Rid.ReviewId == review.ReviewId);
            if (db != null && dbreview != null)
            {
                db.Reviews.Update(review);
                await db.SaveChangesAsync();
                return review;

            }
            else
            {
                return null;
            }
        }

        #endregion

        #region View all Review based on a movie

        public async Task<List<ReviewModel>> ViewAllReview(int id)
        {
            if (db != null)
            {
                return await (from m in db.Movies
                              from r in db.Reviews
                              where m.MovieId == r.MovieId && r.MovieId == id

                              select new ReviewModel
                              {
                                  MovieTitle = m.MovieTitle,
                                  Comments = r.Comments
                              }).ToListAsync();
            }
            return null;
        }

        #endregion
    }
}
