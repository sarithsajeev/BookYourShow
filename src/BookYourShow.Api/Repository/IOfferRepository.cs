using BookYourShow.Api.ViewModel;
using BookYourShow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourShow.Api.Repository
{
    public interface IOfferRepository
    {
        /// <summary>
        /// Get Offers By Movie
        /// </summary>
        /// <returns></returns>
        Task<List<OfferViewModel>> OfferByMovie();
        /// <summary>
        /// Add Offers
        /// </summary>
        /// <param name="offer"></param>
        /// <returns></returns>
        Task<Offers> AddOffers(Offers offer);
        /// <summary>
        /// Update the offers
        /// </summary>
        /// <param name="offer"></param>
        /// <returns></returns>
        Task<Offers> UpdateOffers(Offers offer);
        /// <summary>
        /// Get Offer By Movie Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<List<OfferViewModel>> GetOfferByMovieId(int id);
    }
}
