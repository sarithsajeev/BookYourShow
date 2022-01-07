using BookYourShow.Api.ViewModel;
using BookYourShow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourShow.Api.Repository
{
    public interface IMovieRepository
    {
        /// <summary>
        /// display movie
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<List<MovieViewModel>> GetMovieById(int id);
        /// <summary>
        /// display Movies
        /// </summary>
        /// <returns></returns>
        Task<List<MovieViewModel>> GetAllMovies();
        /// <summary>
        /// insert Movie
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        Task<Movies> AddMovie(Movies movie);
        /// <summary>
        /// update Movie
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        Task<Movies> UpdateMovie(Movies movie);
        /// <summary>
        /// delete Movie
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Movies> DeleteMovie(int id);

    }
}
