using BookYourShow.Api.ViewModel;
using BookYourShow.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourShow.Api.Repository
{
    public class OfferRepository : IOfferRepository
    {
        private BookYourShowContext _db;

        public OfferRepository(BookYourShowContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Get Offer By Movie 
        /// </summary>
        /// <returns></returns>
        #region Get Movie Offer
        public async Task<List<OfferViewModel>> OfferByMovie()
        {
            if (_db != null)
            {
                return await (from a in _db.Movies
                              join b in _db.Offers
                              on a.OfferId equals b.OfferId
                              select new OfferViewModel
                              {
                                  MovieId = a.MovieId,
                                  MovieTitle = a.MovieTitle,
                                  MovieDesc = a.MovieDesc,
                                  MovieRelease = a.MovieRelease,
                                  OfferId = b.OfferId,
                                  OfferName = b.OfferName,
                                  OfferDescription = b.OfferDescription


                              }).ToListAsync();
            }
            return null;
        }


        #endregion

        #region Get Movie Offer By Movie Id
        public async Task<List<OfferViewModel>> GetOfferByMovieId(int id)
        {
            if (_db != null)
            {
                return await (from a in _db.Movies
                              join b in _db.Offers
                              on a.OfferId equals b.OfferId
                              where a.MovieId == id
                              select new OfferViewModel
                              {
                                  MovieId = a.MovieId,
                                  MovieTitle = a.MovieTitle,
                                  MovieDesc = a.MovieDesc,
                                  MovieRelease = a.MovieRelease,
                                  OfferId = b.OfferId,
                                  OfferName = b.OfferName,
                                  OfferDescription = b.OfferDescription


                              }).ToListAsync();
            }
            return null;
        }


        #endregion

        #region Add Offers
        public async Task<Offers> AddOffers(Offers offer)
        {
            if (_db != null)
            {
                await _db.Offers.AddAsync(offer);
                await _db.SaveChangesAsync();
                return offer;
            }
            return null;
        }
        #endregion

        #region
        public async Task<Offers> UpdateOffers(Offers offer)
        {
            if (_db != null)
            {
                _db.Offers.Update(offer);
                await _db.SaveChangesAsync();
                return offer;
            }
            return null;
        }
        #endregion
    }
}
