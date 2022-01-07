using BookYourShow.Api.ViewModel;
using BookYourShow.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourShow.Api.Repository
{
    public class MovieRepository : IMovieRepository
    {
        BookYourShowContext _db;
        public MovieRepository(BookYourShowContext db)
        {
            _db = db;
        }
        //get movies
        public async Task<List<MovieViewModel>> GetAllMovies()
        {
            if (_db != null)
            {
                //joining and getting 
                return await (from movie in _db.Movies
                              from language in _db.Languages
                              from genre in _db.Genres
                              from offer in _db.Offers
                              where movie.LangId == language.LangId
                              where movie.GenreId == genre.GenreId
                              where movie.OfferId == offer.OfferId
                              select new MovieViewModel
                              {
                                  MovieId = movie.MovieId,
                                  MovieTitle = movie.MovieTitle,
                                  MovieDesc = movie.MovieDesc,
                                  MovieRelease = movie.MovieRelease,
                                  Language = language.Language,
                                  Genre = genre.Genre,
                                  OfferName = offer.OfferName,
                                  OfferDescription = offer.OfferDescription,
                                  IsActive = movie.IsActive
                              }
                              ).ToListAsync();

            }
            return null;
        }
        //getmoviebyid
        public async Task<List<MovieViewModel>> GetMovieById(int id)
        {
            if (_db != null)
            {
                //joining and getting 
                return await (from movie in _db.Movies
                              from language in _db.Languages
                              from genre in _db.Genres
                              from offer in _db.Offers
                              where movie.MovieId == id
                              where movie.LangId == language.LangId
                              where movie.GenreId == genre.GenreId
                              where movie.OfferId == offer.OfferId
                              select new MovieViewModel
                              {
                                  MovieId = movie.MovieId,
                                  MovieTitle = movie.MovieTitle,
                                  MovieDesc = movie.MovieDesc,
                                  MovieRelease = movie.MovieRelease,
                                  Language = language.Language,
                                  Genre = genre.Genre,
                                  OfferName = offer.OfferName,
                                  OfferDescription = offer.OfferDescription,
                                  IsActive = movie.IsActive
                              }
                              ).ToListAsync();

            }
            return null;
        }

        //Add movie

        public async Task<Movies> AddMovie(Movies movie)
        {
            //--- member function to add movie ---//
            if (_db != null)
            {
                await _db.Movies.AddAsync(movie);
                await _db.SaveChangesAsync();
                return movie;
            }
            return null;

        }
        //Update movie
        public async Task<Movies> UpdateMovie(Movies movie)
        {
            //member function to update movie
            if (_db != null)
            {
                _db.Movies.Update(movie);
                await _db.SaveChangesAsync();
                return movie;
            }
            return null;
        }
        //Delete movie
        public async Task<Movies> DeleteMovie(int id)
        {
            //member function to delete movie
            if (_db != null)
            {
                Movies movie = await _db.Movies.FirstOrDefaultAsync(em => em.MovieId == id);
                movie.IsActive = false;
                _db.Movies.Update(movie);
                await _db.SaveChangesAsync();
                return movie;
            }
            return null;
        }

    }
}
